using DownLoad.Core;
using DownLoad.Core.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DownLoad.UI
{
    public partial class MapXmlFrm : FrmBase
    {
        public string MapJson { get; set; }
        public MapXmlFrm(string xml,string caption)
        {
            InitializeComponent();
            this.LoadXml(xml);
            this.Text = "【" + caption + "】Xml映射";
        }

        private void LoadXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return;
            SchemaInfo info = JsonConvert.DeserializeObject<SchemaInfo>(xml);
            if (info == null)
                return;
            this.txtns.Text = info.RemoveNs;
            this.txtnode.Text = info.ExecuteNode;
            this.txtCdata.Text = info.CData;
            this.LoadGrid(info.TableSchema);
        }
        private void LoadGrid(List<TableSchema> list)
        {
            if (list != null)
            {
                this.dataGridView1.Rows.Clear();

                foreach (TableSchema item in list)
                {
                    int index = this.dataGridView1.Rows.Add(1);
                    DataGridViewRow dr = this.dataGridView1.Rows[index];
                    dr.Cells[0].Value = item.column;
                    dr.Cells[1].Value = item.maptype;
                    dr.Cells[2].Value = item.attr;
                    dr.Cells[3].Value = item.map;
                    dr.Cells[4].Value = item.relemap;
                }
            }
        }
        private void btncancle_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            this.MapJson = this.txtjson.Text.Trim();
            base.DialogResult = DialogResult.OK;
        }

        private void btngenerate_Click(object sender, EventArgs e)
        {
            this.GenerateXml();        
        }

        private void GenerateXml()
        {
            this.txtjson.Text = this.GenerateSchema().ToString();
        }
        private SchemaInfo GenerateSchema()
        {
            SchemaInfo info = new SchemaInfo();
            info.TableSchema = new List<TableSchema>();          
            foreach (DataGridViewRow item in this.dataGridView1.Rows)
            {
                TableSchema ts = new TableSchema();
                ts.column = item.Cells[0].Value != null ? item.Cells[0].Value.ToString() : "";
                ts.maptype = item.Cells[1].Value != null ? item.Cells[1].Value.ToString() : "";
                ts.attr = item.Cells[2].Value != null ? item.Cells[2].Value.ToString() : "";
                ts.map = item.Cells[3].Value != null ? item.Cells[3].Value.ToString() : "";
                ts.relemap = item.Cells[4].Value != null ? item.Cells[4].Value.ToString() : "";
                info.TableSchema.Add(ts);
            }
            info.ExecuteNode = this.txtnode.Text.Trim();
            info.RemoveNs = this.txtns.Text.Trim();
            info.CData = this.txtCdata.Text.Trim();
            info.TableSchema.RemoveAll(a => string.IsNullOrEmpty(a.column));
            return info;
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
            using (ShowPathFrm path = new ShowPathFrm(dr))
            {
                path.ShowDialog();
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.GenerateXml();
        }

        private void txtnode_TextChanged(object sender, EventArgs e)
        {
            this.GenerateXml();
        }
    }
}
