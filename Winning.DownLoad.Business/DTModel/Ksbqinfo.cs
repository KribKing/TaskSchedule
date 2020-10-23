using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.DTModel
{
    [Serializable]
    public class KsbqinfoList
    {
        public bool flag { get; set; }
        public string msg { get; set; }
        public List<Ksbqinfo> datas { get; set; }
    }
    [Serializable]
    public class Ksbqinfo
    {
        private string _ID;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _KSDM;

        public string KSDM
        {
            get { return _KSDM; }
            set { _KSDM = value; }
        }
        private string _KSMC;

        public string KSMC
        {
            get { return _KSMC; }
            set { _KSMC = value; }
        }
        private string _BQDM;

        public string BQDM
        {
            get { return _BQDM; }
            set { _BQDM = value; }
        }
        private string _BQMC;

        public string BQMC
        {
            get { return _BQMC; }
            set { _BQMC = value; }
        }
        private string _MEMO;

        public string MEMO
        {
            get { return _MEMO; }
            set { _MEMO = value; }
        }
    }
}
