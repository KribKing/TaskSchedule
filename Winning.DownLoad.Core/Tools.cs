using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Winning.DownLoad.Core
{
    public class Tools
    {
        #region 声明变量
        public static string logpath = null;
        public static bool islog = false;
        #endregion

        #region  构造函数
        //public Tools()
        //{
        //    //logpath = ConfigurationManager.AppSettings["LogPath"];
        //}
        #endregion

        #region XmlStringToDataSet
        /// <summary>
        /// A function that takes an XML string and converts it into a DataSet
        /// </summary>
        /// <param name="xmlString">The xml string to tranform into a DataSet</param>
        /// <returns>The DataSet representing the values and schema from our xml string</returns>
        public static DataSet XmlStringToDataSet(string xmlString)
        {
            //create a new DataSet that will hold our values
            DataSet quoteDataSet = null;

            //check if the xmlString is not blank
            if (String.IsNullOrEmpty(xmlString))
            {
                //stop the processing
                return quoteDataSet;
            }

            try
            {
                //create a StringReader object to read our xml string
                using (StringReader stringReader = new StringReader(xmlString))
                {
                    //initialize our DataSet
                    quoteDataSet = new DataSet();

                    //load the StringReader to our DataSet
                    quoteDataSet.ReadXml(stringReader);
                }
            }
            catch
            {
                //return null
                quoteDataSet = null;
            }

            //return the DataSet containing the stock information
            return quoteDataSet;
        }
        #endregion

        #region DataSetToXmlString
        /// <summary>
        /// A function that takes a DataSet string and converts it into an XML
        /// </summary>
        /// <param name=" quoteDataSet ">T </param>
        /// <returns>xml string</returns>
        public static string DataSetToXmlString(DataSet quoteDataSet)
        {
            return quoteDataSet.GetXml().Replace(" ", "");
        }
        #endregion

        #region DataSetToString
        /// <summary>
        /// 自动生成xml
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private static string DataSetToString(DataSet ds)
        {
            try
            {
                //StringBuilder sb = new StringBuilder();
                //sb.AppendLine("<?xml version=\"1.0\" encoding=\"GB2312\" standalone=\"yes\"?>");
                //StringWriter sw=new StringWriter (sb);

                //ds.WriteXml(XmlTextWriter.Create(sb));
                //return sb.ToString();
                MemoryStream ms = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(ms, Encoding.UTF8);
                ds.WriteXml(writer);
                int count = (int)ms.Length;
                byte[] arr = new byte[count];
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                ms.Read(arr, 0, count);
                string strxml = Encoding.UTF8.GetString(arr).Trim();
                return strxml;
            }
            catch// (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return "";
        }
        #endregion
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string DESEnCode(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.GetEncoding("UTF-8").GetBytes(pToEncrypt);


            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }

        /**/
        /// <summary>
        /// 将DataTable对象转换成XML字符串
        /// </summary>
        /// <param name="dt">DataTable对象</param>
        /// <returns>XML字符串</returns>
        public static string CDataToXml(DataTable dt)
        {
            if (dt != null)
            {
                MemoryStream ms = null;
                XmlTextWriter XmlWt = null;
                try
                {
                    ms = new MemoryStream();
                    //根据ms实例化XmlWt
                    XmlWt = new XmlTextWriter(ms, Encoding.UTF8);
                    //获取ds中的数据
                    dt.WriteXml(XmlWt);
                    int count = (int)ms.Length;
                    byte[] temp = new byte[count];
                    ms.Seek(0, SeekOrigin.Begin);
                    ms.Read(temp, 0, count);
                    //返回Unicode编码的文本
                    UTF8Encoding ucode = new UTF8Encoding();
                    string returnValue = ucode.GetString(temp).Trim();
                    return ("<?xml version=" + '"' + "1.0" + '"' + " " + "encoding=" + '"' + "UTF-8" + '"' + "?>" + returnValue);
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    //释放资源
                    if (XmlWt != null)
                    {
                        XmlWt.Close();
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
            else
            {
                return "";
            }
        }

        /**/
        /// <summary>
        /// 将Xml内容字符串转换成DataSet对象
        /// </summary>
        /// <param name="xmlStr">Xml内容字符串</param>
        /// <returns>DataSet对象</returns>
        public static DataSet CXmlToDataSet(string xmlStr)
        {
            if (!string.IsNullOrEmpty(xmlStr))
            {
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try
                {
                    DataSet ds = new DataSet();
                    //读取字符串中的信息
                    StrStream = new StringReader(xmlStr);
                    //获取StrStream中的数据
                    Xmlrdr = new XmlTextReader(StrStream);
                    //ds获取Xmlrdr中的数据                
                    ds.ReadXml(Xmlrdr);
                    return ds;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    //释放资源
                    if (Xmlrdr != null)
                    {
                        Xmlrdr.Close();
                        StrStream.Close();
                        StrStream.Dispose();
                    }
                }
            }
            else
            {
                return null;
            }
        }

        #region  对hl7解析
        /// <summary>
        /// 将HL7内容字符串转换成DataSet对象
        /// </summary>
        /// <param name="xmlStr">HL7内容字符串</param>
        /// <returns>DataSet对象</returns>

        public static DataSet Hl7ToDataSet(string Shl7)
        {
            if (!string.IsNullOrEmpty(Shl7))
            {
                try
                {
                    //将hl7分成段
                    string[] Shl7Lines = Shl7.Split('\r');
                    //定义datatable,dataset 存放hl7每一行的值
                    DataSet Ds = new DataSet();
                    for (int i = 0; i <= Shl7Lines.Length - 1; i++)
                    {  //判断是否为空
                        if (Shl7Lines[i] != string.Empty)
                        {
                            string Shl7Line = Shl7Lines[i];
                            //获取每一行字段值
                            string[] SFields = Shl7Line.Split('|');
                            //动态向dataset增加表
                            Ds.Tables.Add(new DataTable(SFields[0].Trim()));
                            Ds.Tables[SFields[0].Trim()].Columns.Add(new DataColumn(("VALUE"), typeof(string)));
                            //向表中添加数据
                            for (int j = 0; j <= SFields.Length - 1; j++)
                            {
                                DataRow Row = Ds.Tables[SFields[0].Trim()].NewRow();
                                Row["VALUE"] = SFields[j].Trim();
                                Ds.Tables[SFields[0].Trim()].Rows.Add(Row);

                            }

                        }
                    }
                    return Ds;

                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            else
            {
                return null;
            }

        }

        #endregion

        #region
        /// <summary>
        /// 将DataSet内容字符串转换成HL7对象
        /// </summary>
        /// 添加hl7一定按照文档上的先后顺序添加
        /// <param name="xmlStr">DataSet内容字符串</param>
        /// <returns>Hl7对象</returns>
        public static string DataSetToHl7(DataSet Ds)
        {
            string RetResult = "";
            if (Ds != null)
            {
                try
                {
                    for (int i = 0; i <= Ds.Tables.Count - 1; i++)
                    {
                        for (int j = 0; j <= Ds.Tables[i].Rows.Count - 1; j++)
                        {
                            for (int Field = 0; Field <= Ds.Tables[i].Columns.Count - 1; Field++)
                            {
                                RetResult = RetResult + Ds.Tables[i].Rows[j][Field].ToString().Trim() + "|";
                            }
                            //循环之后将最后一个|去掉，加\r\n
                            RetResult = RetResult.Substring(0, RetResult.Length - 1);
                            RetResult = RetResult + "<CR>";//<CR>

                        }
                    }
                    //返回结果
                    return RetResult;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 写日记
        public static void log(string logtext)
        {
            try
            {
                ///if (islog == false) return;
                string path = logpath + DateTime.Now.ToString("yyyyMMdd") + '_' + "HSJK_LOG.txt";
                if (!(File.Exists(path)))
                {
                    StreamWriter sw;
                    sw = File.CreateText(path);
                    sw.Close();
                }

                logtext = DateTime.Now.ToString("G") + ": " + logtext;

                using (StreamWriter wr = File.AppendText(path))
                {
                    wr.WriteLine(logtext);
                    wr.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("记录日记失败" + ex.Message);
            };

        }
        #endregion

        #region 写日记
        public static void log(string logtext, string jymc)
        {
            try
            {
                ///if (islog == false) return;
                string path = logpath + DateTime.Now.ToString("yyyyMMdd") + '_' + "HSJK" + jymc + "_LOG.log";
                if (!(File.Exists(path)))
                {
                    StreamWriter sw;
                    sw = File.CreateText(path);
                    sw.Close();
                }

                logtext = DateTime.Now.ToString("G") + ": " + logtext;

                using (StreamWriter wr = File.AppendText(path))
                {
                    wr.WriteLine(logtext);
                    wr.Close();
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("记录日记失败" + ex.Message);
            };
        }
        #endregion

        /// <summary>
        /// List转成DataTable
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entities">实体集合</param>
        public static DataTable ToDataTable<T>(List<T> entities)
        {
            if (entities == null || entities.Count == 0)
            {
                return null;
            }

            var result = CreateTable<T>();
            FillData(result, entities);
            return result;
        }
        /// <summary>
        /// 创建表
        /// </summary>
        private static DataTable CreateTable<T>()
        {
            var result = new DataTable();
            var type = typeof(T);
            foreach (var property in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                var propertyType = property.PropertyType;
                if ((propertyType.IsGenericType) && (propertyType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    propertyType = propertyType.GetGenericArguments()[0];
                result.Columns.Add(property.Name, propertyType);
            }
            return result;
        }
        /// <summary>
        /// 填充数据
        /// </summary>
        private static void FillData<T>(DataTable dt, IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                dt.Rows.Add(CreateRow(dt, entity));
            }
        }

        /// <summary>
        /// 创建行
        /// </summary>
        private static DataRow CreateRow<T>(DataTable dt, T entity)
        {
            DataRow row = dt.NewRow();
            Type type = typeof(T);
            foreach (PropertyInfo property in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                row[property.Name] = property.GetValue(entity, null) ?? DBNull.Value;
            }
            return row;
        }

        /// <summary>
        /// DataTable转成List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToDataList<T>(DataTable dt)
        {
            var list = new List<T>();
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());
            foreach (DataRow item in dt.Rows)
            {
                T s = Activator.CreateInstance<T>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    PropertyInfo info = plist.Find(p => p.Name == dt.Columns[i].ColumnName);
                    if (info != null)
                    {
                        try
                        {
                            if (!Convert.IsDBNull(item[i]))
                            {
                                object v = null;
                                if (info.PropertyType.ToString().Contains("System.Nullable"))
                                {
                                    v = Convert.ChangeType(item[i], Nullable.GetUnderlyingType(info.PropertyType));
                                }
                                else
                                {
                                    v = Convert.ChangeType(item[i], info.PropertyType);
                                }
                                info.SetValue(s, v, null);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("字段[" + info.Name + "]转换出错," + ex.Message);
                        }
                    }
                }
                list.Add(s);
            }
            return list;
        }

        #region 删除DataTable重复列，类似distinct
        /// <summary>   
        /// 删除DataTable重复列，类似distinct   
        /// </summary>   
        /// <param name="dt">DataTable</param>   
        /// <param name="Field">字段名</param>   
        /// <returns></returns>   
        public static DataTable DeleteSameRow(DataTable dt, string Field)
        {
            ArrayList indexList = new ArrayList();
            // 找出待删除的行索引   
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                if (!IsContain(indexList, i))
                {
                    for (int j = i + 1; j < dt.Rows.Count; j++)
                    {
                        if (dt.Rows[i][Field].ToString() == dt.Rows[j][Field].ToString())
                        {
                            indexList.Add(j);
                        }
                    }
                }
            }
            indexList.Sort();
            // 排序
            for (int i = indexList.Count - 1; i >= 0; i--)// 根据待删除索引列表删除行  
            {
                int index = Convert.ToInt32(indexList[i]);
                dt.Rows.RemoveAt(index);
            }
            return dt;
        }

        /// <summary>   
        /// 判断数组中是否存在   
        /// </summary>   
        /// <param name="indexList">数组</param>   
        /// <param name="index">索引</param>   
        /// <returns></returns>   
        public static bool IsContain(ArrayList indexList, int index)
        {
            for (int i = 0; i < indexList.Count; i++)
            {
                int tempIndex = Convert.ToInt32(indexList[i]);
                if (tempIndex == index)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        public static string ConvertJsonString(string str)
        {
            //格式化json字符串
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }
        public static List<T> Clone<T>(object List)
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, List);
                objectStream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(objectStream) as List<T>;
            }
        }
        /// <summary>  
        /// 修改程序在注册表中的键值  
        /// </summary>  
        /// <param name="isAuto">true:开机启动,false:不开机自启</param> 
        public static void AutoStart(bool isAuto = true, string appname = "定时处理程序", bool showinfo = true)
        {
            try
            {
                if (isAuto == true)
                {
                    //RegistryKey R_local = Registry.CurrentUser;//注册当前用户;
                    RegistryKey R_local = Registry.LocalMachine;//注册到机器
                    RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    R_run.SetValue(appname, Application.ExecutablePath);
                    R_run.Close();
                    R_local.Close();
                }
                else
                {
                    //RegistryKey R_local = Registry.CurrentUser;//注册当前用户;
                    RegistryKey R_local = Registry.LocalMachine;//注册到机器
                    RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    R_run.DeleteValue(appname, false);
                    R_run.Close();
                    R_local.Close();
                }
            }
            catch (Exception)
            {
                if (showinfo)
                    MessageBox.Show("您需要管理员权限修改", "提示");
            }
        }
        /// <summary>
        /// 获取Json节点数值
        /// </summary>
        /// <param name="json"></param>
        /// <param name="key"></param>
        /// <param name="defaultvalue"></param>
        /// <returns></returns>
        public static object GetJsonNodeValue(string json, string key, string defaultvalue = "")
        {
            string value = "";
            try
            {
                if (key.Contains("|"))
                {
                    string[] keys = key.Split('|');
                    JObject jsonObject = (JObject)JsonConvert.DeserializeObject(json);
                   
                    for (int i = 0; i < keys.Length; i++)
                    {
                        if (i == keys.Length - 1)
                        {
                            value = (jsonObject[keys[i]] ?? defaultvalue).ToString();
                        }
                        else
                        {
                            jsonObject = (JObject)jsonObject[keys[i]];
                        }
                    }

                }
                else
                {
                    JObject jsonObject = (JObject)JsonConvert.DeserializeObject(json);
                    value = (jsonObject[key]?? defaultvalue).ToString();
                }

            }
            catch
            {
                throw;
            }

            return value;
        }

        public static DataTable JsonToDataTable(string json)
        {
            DataTable table = new DataTable();
            //JsonStr为Json字符串
            JArray array = JsonConvert.DeserializeObject(json) as JArray;//反序列化为数组
            if (array.Count > 0)
            {
                StringBuilder columns = new StringBuilder();

                JObject objColumns = array[0] as JObject;
                //构造表头
                foreach (JToken jkon in objColumns.AsEnumerable<JToken>())
                {
                    string name = ((JProperty)(jkon)).Name;
                    columns.Append(name + ",");
                    table.Columns.Add(name);
                }
                //向表中添加数据
                for (int i = 0; i < array.Count; i++)
                {
                    DataRow row = table.NewRow();
                    JObject obj = array[i] as JObject;
                    foreach (JToken jkon in obj.AsEnumerable<JToken>())
                    {

                        string name = ((JProperty)(jkon)).Name;
                        string value = ((JProperty)(jkon)).Value.ToString();
                        row[name] = value;
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }
    }
}
