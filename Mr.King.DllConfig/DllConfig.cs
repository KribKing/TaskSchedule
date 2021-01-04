using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
namespace Mr.King.DllConfig
{
    public class DllConfig
    {
        public static void ShowMsg()
        {
            MessageBox.Show(GetConfigInfo()["Msg"].ToString());
        }
        protected static Dictionary<string, string> GetConfigInfo()
        {
            Dictionary<string, string> dicInfo = new Dictionary<string, string>();
            ExeConfigurationFileMap map;

            map = new ExeConfigurationFileMap();
            Assembly assembly = Assembly.GetCallingAssembly();
            Uri uri = new Uri(Path.GetDirectoryName(assembly.CodeBase));

            map.ExeConfigFilename = Path.Combine(uri.LocalPath, assembly.GetName().Name + ".dll.config");
            if (!System.IO.File.Exists(map.ExeConfigFilename))
            {
                //WriteLog(string.Format("配置文件路径不存在,{0}", map.ExeConfigFilename));
                return dicInfo;
            }

            KeyValueConfigurationCollection col = ConfigurationManager.OpenMappedExeConfiguration(map, 0).AppSettings.Settings;

            foreach (KeyValueConfigurationElement s in col)
            {
                dicInfo.Add(s.Key, s.Value);
            }

            return dicInfo;
        }
    }
}
