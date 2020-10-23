using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Services.Description;

namespace Winning.DownLoad.Core
{
    public class GlobalWebRequestHelper
    {

        private static Dictionary<string, Assembly> _dicWebServiceAssemblys = new Dictionary<string, Assembly>();
        private static Dictionary<string, string> _dicWebServiceClassName = new Dictionary<string, string>();
        public static string HttpGetRequest(string url, string body, string token = "", string accept = "json", string contentttype = "json")
        {
            try
            {
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url+body);
                request.Method = "GET";
                request.Accept = "application/" + accept;
                request.ContentType = "application/" + contentttype + "; charset=utf-8";
                request.UserAgent = "Apache-HttpClient/4.1.1 (java 1.5)";
                request.AllowAutoRedirect = false;
                request.Headers.Add("access_token", token);            
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    return reader.ReadToEnd();
                }
            }
            catch
            {
                throw;
            }
        }
        public static string HttpPostRequest(string url, string body, string token = "", string accept = "json", string contentttype = "json")
        {                     
            try
            {          
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Accept = "application/" + accept;
                request.ContentType = "application/" + contentttype + "; charset=utf-8";         
                //request.UserAgent = "Apache-HttpClient/4.1.1 (java 1.5)";
                request.AllowAutoRedirect = false;
                request.Headers.Add("access_token", token);
                byte[] buffer = encoding.GetBytes(body);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    return reader.ReadToEnd();      
                }
                //response.Close();
                //request.Abort();
                
            }
            catch
            {
                throw;
            }
           
        }
        public static string SoapRequest(string url, object[] args, string method)
        {
            //这里的namespace是需引用的webservices的命名空间，在这里是写死的，大家可以加一个参数从外面传进来。
            string @namespace = "client";
            try
            {
                System.Reflection.Assembly assembly = null;
                string classname = string.Empty;
                if (_dicWebServiceAssemblys.ContainsKey(url) == false)
                {
                    //获取WSDL
                    WebClient wc = new WebClient();
                    Stream stream = wc.OpenRead(url + "?WSDL");
                    ServiceDescription sd = ServiceDescription.Read(stream);
                    classname = sd.Services[0].Name;
                    ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                    sdi.AddServiceDescription(sd, "", "");
                    CodeNamespace cn = new CodeNamespace(@namespace);

                    //生成客户端代理类代码
                    CodeCompileUnit ccu = new CodeCompileUnit();
                    ccu.Namespaces.Add(cn);
                    sdi.Import(cn, ccu);
                    CSharpCodeProvider csc = new CSharpCodeProvider();
                    ICodeCompiler icc = csc.CreateCompiler();

                    //设定编译参数
                    CompilerParameters cplist = new CompilerParameters();
                    cplist.GenerateExecutable = false;
                    cplist.GenerateInMemory = true;
                    cplist.ReferencedAssemblies.Add("System.dll");
                    cplist.ReferencedAssemblies.Add("System.XML.dll");
                    cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                    cplist.ReferencedAssemblies.Add("System.Data.dll");

                    //编译代理类
                    CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);
                    if (true == cr.Errors.HasErrors)
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                        {
                            sb.Append(ce.ToString());
                            sb.Append(System.Environment.NewLine);
                        }
                        throw new Exception(sb.ToString());
                    }

                    //生成代理实例，并调用方法
                    assembly = cr.CompiledAssembly;
                    lock (_dicWebServiceAssemblys)
                    {
                        if (_dicWebServiceAssemblys.ContainsKey(url) == false)
                            _dicWebServiceAssemblys.Add(url, assembly);
                    }
                    lock (_dicWebServiceClassName)
                    {
                        if (_dicWebServiceClassName.ContainsKey(url) == false)
                            _dicWebServiceClassName.Add(url, classname);
                    }
                }
                else
                {
                    assembly = _dicWebServiceAssemblys[url];
                    classname = _dicWebServiceClassName[url];
                }
                Type t = assembly.GetType(@namespace + "." + classname, true, true);
                object obj = Activator.CreateInstance(t);
                System.Reflection.MethodInfo mi = t.GetMethod(method);
                return mi.Invoke(obj, args).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
                // return null;
            }
            finally
            {
                //GC.Collect();
            }
        }
    }
}
