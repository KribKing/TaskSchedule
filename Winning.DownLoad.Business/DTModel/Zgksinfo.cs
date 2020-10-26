using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.DTModel
{
    [Serializable]
    public class ZgksinfoList
    {
        public bool flag { get; set; }
        public string msg { get; set; }
        public List<Zgksinfo> datas { get; set; }
    }
    [Serializable]
    public class Zgksinfo
    {
        private string _ZGDM;

        public string ZGDM
        {
            get { return _ZGDM; }
            set { _ZGDM = value; }
        }
        private string _SDM;

        public string SDM
        {
            get { return _SDM; }
            set { _SDM = value; }
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
    }
}
