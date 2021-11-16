using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SwitchConfig
{
    public partial class FrmMain : Form
    {
        private readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SetConfig.xml");
        private readonly string newpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings\\JobSettingForSyncData.json");
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(path)) return;
                DataTable dt = new DataTable();
                dt.ReadXml(path);
                List<JobInfo> list = ToDataList<JobInfo>(dt);
                List<JobNewInfo> newlist = JsonConvert.DeserializeObject<List<JobNewInfo>>(JsonConvert.SerializeObject(list));
                if (!File.Exists(newpath))
                    File.Create(newpath);
                File.WriteAllText(newpath, JsonConvert.DeserializeObject(JsonConvert.SerializeObject(newlist)).ToString());
                MessageBox.Show("转换发生完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show("转换发生异常" + ex.Message);
            }
        }

        public List<T> ToDataList<T>(DataTable dt)
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
    }
}
