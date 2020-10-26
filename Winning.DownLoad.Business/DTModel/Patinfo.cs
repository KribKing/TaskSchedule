using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.DTModel
{
    [Serializable]
    public class PatinfoList
    {
        public bool flag { get; set; }
        public string msg { get; set; }
        public List<Patinfo> datas { get; set; }
    }
    [Serializable]
    public class Patinfo
    {
        private string _patid;

        public string patid
        {
            get { return _patid; }
            set { _patid = value; }
        }
        private string _blh;

        public string blh
        {
            get { return _blh; }
            set { _blh = value; }
        }
        private string _hzxm;

        public string hzxm
        {
            get { return _hzxm; }
            set { _hzxm = value; }
        }
        private string _wb;

        public string wb
        {
            get { return _wb; }
            set { _wb = value; }
        }
        private string _py;

        public string py
        {
            get { return _py; }
            set { _py = value; }
        }
        private string _cardno;

        public string cardno
        {
            get { return _cardno; }
            set { _cardno = value; }
        }
        private int _zypatid;
        public int zypatid
        {
            get { return _zypatid; }
            set { _zypatid = value; }
        }
        private string _sbh;

        public string sbh
        {
            get { return _sbh; }
            set { _sbh = value; }
        }
        private string _qtkh;

        public string qtkh
        {
            get { return _qtkh; }
            set { _qtkh = value; }
        }
        private string _sfzh;

        public string sfzh
        {
            get { return _sfzh; }
            set { _sfzh = value; }
        }
        private string _sex;

        public string sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        //private string _birth;
        //public string birth
        //{
        //    get { return _birth; }
        //    set { _birth = value; }
        //}
        private string _lxdz;

        public string lxdz
        {
            get { return _lxdz; }
            set { _lxdz = value; }
        }
        private string _lxdh;

        public string lxdh
        {
            get { return _lxdh; }
            set { _lxdh = value; }
        }
        private string _yzbm;

        public string yzbm
        {
            get { return _yzbm; }
            set { _yzbm = value; }
        }
        private string _lxr;

        public string lxr
        {
            get { return _lxr; }
            set { _lxr = value; }
        }
        private string _ybdm;

        public string ybdm
        {
            get { return _ybdm; }
            set { _ybdm = value; }
        }
        private string _pzh;

        public string pzh
        {
            get { return _pzh; }
            set { _pzh = value; }
        }
        private string _dwbm;

        public string dwbm
        {
            get { return _dwbm; }
            set { _dwbm = value; }
        }
        private string _dwmc;

        public string dwmc
        {
            get { return _dwmc; }
            set { _dwmc = value; }
        }
        private string _qxdm;

        public string qxdm
        {
            get { return _qxdm; }
            set { _qxdm = value; }
        }
        private decimal _zhje;

        public decimal zhje
        {
            get { return _zhje; }
            set { _zhje = value; }
        }
        private decimal _ljje;

        public decimal ljje
        {
            get { return _ljje; }
            set { _ljje = value; }
        }
        private string _zhszrq;

        public string zhszrq
        {
            get { return _zhszrq; }
            set { _zhszrq = value; }
        }
        private string _zjrq;

        public string zjrq
        {
            get { return _zjrq; }
            set { _zjrq = value; }
        }
        private string _czyh;

        public string czyh
        {
            get { return _czyh; }
            set { _czyh = value; }
        }
        private string _lrrq;

        public string lrrq
        {
            get { return _lrrq; }
            set { _lrrq = value; }
        }
        private int _tybz;

        public int tybz
        {
            get { return _tybz; }
            set { _tybz = value; }
        }
        private string _cardtype;

        public string cardtype
        {
            get { return _cardtype; }
            set { _cardtype = value; }
        }
        private int _xtbz;

        public int xtbz
        {
            get { return _xtbz; }
            set { _xtbz = value; }
        }
    }
}
