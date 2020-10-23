using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.DTModel
{
    [Serializable]
    public class JzpatinfoList
    {
        public bool flag { get; set; }
        public string msg { get; set; }
        public List<Jzpatinfo> datas { get; set; }
    }
    [Serializable]
    public class Jzpatinfo
    {
        private string _patid;

        public string patid
        {
            get { return _patid; }
            set { _patid = value; }
        }
        private string _syxh;

        public string syxh
        {
            get { return _syxh; }
            set { _syxh = value; }
        }
        private string _cwdm;

        public string cwdm
        {
            get { return _cwdm; }
            set { _cwdm = value; }
        }
        private string _blh;

        public string blh
        {
            get { return _blh; }
            set { _blh = value; }
        }
        private string _kh;

        public string kh
        {
            get { return _kh; }
            set { _kh = value; }
        }
        private string _hzxm;

        public string hzxm
        {
            get { return _hzxm; }
            set { _hzxm = value; }
        }
        private string _xb;

        public string xb
        {
            get { return _xb; }
            set { _xb = value; }
        }
        private string _nl;

        public string nl
        {
            get { return _nl; }
            set { _nl = value; }
        }
        private string _csrq;

        public string csrq
        {
            get { return _csrq; }
            set { _csrq = value; }
        }
        private string _sfzh;

        public string sfzh
        {
            get { return _sfzh; }
            set { _sfzh = value; }
        }
        private string _ksdm;

        public string ksdm
        {
            get { return _ksdm; }
            set { _ksdm = value; }
        }
        private string _ksmc;

        public string ksmc
        {
            get { return _ksmc; }
            set { _ksmc = value; }
        }
        private string _bqdm;

        public string bqdm
        {
            get { return _bqdm; }
            set { _bqdm = value; }
        }
        private string _bqmc;

        public string bqmc
        {
            get { return _bqmc; }
            set { _bqmc = value; }
        }
        //private decimal? _pdlsh;

        //public decimal? pdlsh
        //{
        //    get { return _pdlsh; }
        //    set { _pdlsh = value; }
        //}
        private int _xtbz;

        public int xtbz
        {
            get { return _xtbz; }
            set { _xtbz = value; }
        }
        private string _memo;

        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        private string _ybsm;

        public string ybsm
        {
            get { return _ybsm; }
            set { _ybsm = value; }
        }
        private string _jzrq;

        public string jzrq
        {
            get { return _jzrq; }
            set { _jzrq = value; }
        }
        private string _zsnr;

        public string zsnr
        {
            get { return _zsnr; }
            set { _zsnr = value; }
        }
        private string _bszy;

        public string bszy
        {
            get { return _bszy; }
            set { _bszy = value; }
        }
        private string _tz;

        public string tz
        {
            get { return _tz; }
            set { _tz = value; }
        }
        private int _crbz=0;
        public int crbz { get; set; }
        private int _brzt=0;

        public int brzt
        {
            get { return _brzt; }
            set { _brzt = value; }
        }

    }
}
