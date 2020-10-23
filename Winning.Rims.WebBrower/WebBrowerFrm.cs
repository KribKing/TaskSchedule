using Gecko;
using Gecko.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winning.Rims.WebBrower
{
    public partial class WebBrowerFrm : Form
    {
        private string testUrl = "http://111.111.111.74:8099/yspreview/index?yydm=&czyh=1275&czymc=吕云";
        public WebBrowerFrm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Geckofx 初始化各项设置
        /// </summary>
        private void GeckoInit()
        {
            #region 设置浏览器各属性，先后顺序不能变
            var app_dir = Environment.CurrentDirectory;//程序目录
            /* 关键代码  */
            //出处：https://www.cnblogs.com/huangcong/p/5796695.html
            string directory = Path.Combine(app_dir, "Cookies", "FireFox");//cookie目录
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);//检测目录是否存在
            Gecko.Xpcom.ProfileDirectory = directory;//绑定cookie目录
            /* 关键代码 结束 */

            Xpcom.Initialize(Path.Combine(app_dir, "FireFox"));//初始化 Xpcom
            //browser = new GeckoWebBrowser() { Dock = DockStyle.Fill }; //创建浏览器实例
            //this.browser.Name = "browser";
            GeckoPreferences.User["gfx.font_rendering.graphite.enabled"] = true;//设置偏好：字体
            GeckoPreferences.User["privacy.donottrackheader.enabled"] = true;//设置浏览器不被追踪
            GeckoPreferences.User["general.useragent.override"] = "User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64; rv:59.0) Gecko/20100101 Firefox/59.0";
            GeckoPreferences.User["intl.accept_languages"] = "zh-CN,zh;q=0.9,en;q=0.8";//不设置的话默认是英文区
            //GeckoPreferences.User["permissions.default.image"] = 2; //  block  image  禁止加载图片
            //GeckoPreferences.User["plugin.state.flash"] = 0;  // bloack flash禁止加载flash 
            //注册事件
            //Gecko.CertOverrideService.GetService().ValidityOverride += geckoWebBrowser1_ValidityOverride;//好像是证书设置回调等
            //browser.DocumentCompleted += Browser_DocumentCompleted;//文档加载完成时间，但js动态生成的这个不准确，据说用状态栏的文字最好
            //browser.CreateWindow += Browser_CreateWindow;//打开新窗口事件，全部设为在同一窗口打开
            //browser.DomClick += browser_DomClick;
            //browser.UseHttpActivityObserver = true;//开启拦截请求
            //browser.ObserveHttpModifyRequest += Browser_ObserveHttpModifyRequest;//拦截请求（在创建窗口之前就拦截。）同时取消创建创建，在主窗口打开
            //Gecko.LauncherDialog.Download += GeckoDownload;//注册下载事件
            #endregion
            /*  备用     
                GeckoPreferences.User["places.history.enabled"] = false;
                GeckoPreferences.User["security.warn_viewing_mixed"] = false;
                GeckoPreferences.User["plugin.state.flash"] = 0;
                GeckoPreferences.User["browser.cache.disk.enable"] = false;
                GeckoPreferences.User["browser.cache.memory.enable"] = false;
                GeckoPreferences.User["browser.xul.error_pages.enabled"] = false;
                GeckoPreferences.User["dom.max_script_run_time"] = 0; //let js run as long as it needs to; prevents timeout errors
                GeckoPreferences.User["browser.download.manager.showAlertOnComplete"] = false;
                GeckoPreferences.User["privacy.popups.showBrowserMessage"] = false;
             */
        }
        /// <summary>
        /// 请求监测，post数据且不打开新窗口，直接在本窗口打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Browser_ObserveHttpModifyRequest(object sender, GeckoObserveHttpModifyRequestEventArgs e)
        {
            try
            {
                if (e.RequestMethod != "POST")
                    return;
                string url = e.Uri.ToString();
                string targetUrl = @"https://";
                if (!url.Contains(targetUrl) && url != targetUrl)
                    return;




                #region 打印log
                //bool print = true;
                //if (print)
                //    {
                //    string str = "";
                //    str += $"\r\n活动观察：Uri = {e.Uri}\r\n";
                //    if (e.ReqBodyContainsHeaders ?? false)
                //        e.RequestHeaders.ForEach(h => { str += $"活动观察：{h.Key}:{h.Value}\r\n"; });
                //    str += $"活动观察：RequestMethod = {e.RequestMethod}\r\n";
                //    str += $"活动观察：Referrer = {e.Referrer}\r\n";
                //    if (e.RequestBody.Length > 0)
                //        str += $"活动观察：RequestBody = {Encoding.Default.GetString(e.RequestBody)}\r\n";
                //    Logger.Log(str);
                //    }
                #endregion




                #region 获取Post数据，转到主窗口，取消新建窗口
                MimeInputStream headers = MimeInputStream.Create(); //复制 header
                if (e.ReqBodyContainsHeaders ?? false)
                {
                    foreach (var h in e.RequestHeaders)
                    {
                        if (h.Key != "Accept")
                            headers.AddHeader(h.Key, h.Value);
                    }
                    //下面几个Header根据实际情况自己添加删除
                    headers.AddHeader("Upgrade-Insecure-Requests", "1");
                    headers.AddHeader("Origin", "https://");
                    headers.AddHeader("Cache-Control", "max-age=0");
                    headers.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
                }




                if (e.RequestBody.Length <= 0)//取post数据
                    return;
                MimeInputStream postData = MimeInputStream.Create();
                string ContentCharset = Encoding.Default.GetString(e.RequestBody);
                //下面这条Split是因为的用的项目post时里面有多余的长度信息，由于长度信息浏览器会自动添加，所以我需要去掉，其他人如果不是这种情况，删除这句
                ContentCharset = ContentCharset.Split("\r\n".ToCharArray()).Where(s => !string.IsNullOrEmpty(s)).First(s => !s.Contains("Content-"));//把包含的header去掉，取出纯post内容
                postData.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                postData.AddContentLength = true;
                postData.SetData(ContentCharset);
                //用本地窗口跳转
                //bool Navigateable = browser.Navigate("{e.Uri}", GeckoLoadFlags.BypassCache, "{e.Referrer}", postData, headers);

                //browser.UseHttpActivityObserver = false;
                //browser.ObserveHttpModifyRequest -= Browser_ObserveHttpModifyRequest;//取消时间监测，因为跳转到新窗口的时候又会触发这个造成死循环
                #endregion
                e.Cancel = true;//取消在新窗口打开
            }
            catch (Exception ex)
            {
                //Logger.Error($"ObserveHttpModifyRequest异常 = {ex}");
            }
        }

        /// <summary>
        /// 打开新窗口事件，全部设为在同一窗口打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Browser_CreateWindow(object sender, GeckoCreateWindowEventArgs e)
        {
            //browser.Navigate(e.Uri);
            e.Cancel = true;
            //e.InitialHeight = 1;
            //e.InitialWidth = 1;
        }








        /// <summary>  
        /// 设置代理 GeckoFx  
        /// </summary>  
        private void GeckoFxSetting()
        {
            var ip = "192.168.1.1";
            var port = "3128";
            Gecko.GeckoPreferences.User["network.proxy.http"] = ip;
            Gecko.GeckoPreferences.User["network.proxy.http_port"] = int.Parse(port);
            Gecko.GeckoPreferences.User["network.proxy.type"] = 1;
            // network.proxy.type 取值  
            //0 – Direct connection, no proxy. (Default)  
            //1 – Manual proxy configuration.  
            //2 – Proxy auto-configuration (PAC).  
            //4 – Auto-detect proxy settings.  
            //5 – Use system proxy settings (Default in Linux).      
        }




        /// <summary>  
        /// 文档单击事件  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private void browser_DomClick(object sender, DomMouseEventArgs e)
        {
            var ele = e.CurrentTarget.CastToGeckoElement();
            ele = e.Target.CastToGeckoElement();
            //短xpath  
            var xpath1 = GetSmallXpath(ele);
            //Logger.Log("xpath1:" + xpath1);
            //长xpath  
            var xpath2 = GetXpath(ele);
            //Logger.Log("xpath2:" + xpath2);
        }
        /// <summary>
        /// 获取短 xpath
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string GetSmallXpath(GeckoNode node)
        {
            if (node == null)
                return "";
            if (node.NodeType == NodeType.Attribute)
            {
                return String.Format("{0}/@{1}", GetSmallXpath(((GeckoAttribute)node).OwnerDocument), node.LocalName);
            }
            if (node.ParentNode == null)
            {
                return "";
            }
            string elementId = ((GeckoHtmlElement)node).Id;
            if (!String.IsNullOrEmpty(elementId))
            {
                return String.Format("//*[@id=\"{0}\"]", elementId);
            }
            int indexInParent = 1;
            GeckoNode siblingNode = node.PreviousSibling;
            while (siblingNode != null)
            {
                if (siblingNode.LocalName == node.LocalName)
                {
                    indexInParent++;
                }
                siblingNode = siblingNode.PreviousSibling;
            }
            return String.Format("{0}/{1}[{2}]", GetSmallXpath(node.ParentNode), node.LocalName, indexInParent);
        }
        /// <summary>
        /// 获取长xpath
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string GetXpath(GeckoNode node)
        {
            if (node == null)
                return "";
            if (node.NodeType == NodeType.Attribute)
            {
                return String.Format("{0}/@{1}", GetXpath(((GeckoAttribute)node).OwnerDocument), node.LocalName);
            }
            if (node.ParentNode == null)
            {
                return "";
            }
            int indexInParent = 1;
            GeckoNode siblingNode = node.PreviousSibling;
            while (siblingNode != null)
            {
                if (siblingNode.LocalName == node.LocalName)
                {
                    indexInParent++;
                }
                siblingNode = siblingNode.PreviousSibling;
            }
            return String.Format("{0}/{1}[{2}]", GetXpath(node.ParentNode), node.LocalName, indexInParent);
        }

        private void WebBrowerFrm_Load(object sender, EventArgs e)
        {
            this.GeckoInit();
            //this.Controls.Add(this.browser);
            this.geckoWebBrowser1.Navigate(testUrl); 
        }
    }
}
