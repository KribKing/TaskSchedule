using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.Model
{
    [Serializable]
    public class XminfoList
    {
        public bool flag { get; set; }
        public string msg { get; set; }
        public List<Xminfo> datas { get; set; }
    }
    [Serializable]
    public class Xminfo
    {
        private string _id;

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _py;

        public string py
        {
            get { return _py; }
            set { _py = value; }
        }

        private string _wb;

        public string wb
        {
            get { return _wb; }
            set { _wb = value; }
        }

        private string _dxmdm;

        public string dxmdm
        {
            get { return _dxmdm; }
            set { _dxmdm = value; }
        }

        private string _xmdw;

        public string xmdw
        {
            get { return _xmdw; }
            set { _xmdw = value; }
        }
        private string _xmgg;

        public string xmgg
        {
            get { return _xmgg; }
            set { _xmgg = value; }
        }
        private decimal _xmdj;

        public decimal xmdj
        {
            get { return _xmdj; }
            set { _xmdj = value; }
        }

        private decimal _yhbl;

        public decimal yhbl
        {
            get { return _yhbl; }
            set { _yhbl = value; }
        }
        private decimal _txbl;

        public decimal txbl
        {
            get { return _txbl; }
            set { _txbl = value; }
        }


        private int _mzzfbz;

        public int mzzfbz
        {
            get { return _mzzfbz; }
            set { _mzzfbz = value; }
        }
        private decimal _mzzfbl;

        public decimal mzzfbl
        {
            get { return _mzzfbl; }
            set { _mzzfbl = value; }
        }

        private int _zyzfbz;

        public int zyzfbz
        {
            get { return _zyzfbz; }
            set { _zyzfbz = value; }
        }
        private decimal _zyzfbl;

        public decimal zyzfbl
        {
            get { return _zyzfbl; }
            set { _zyzfbl = value; }
        }
        private string _xmlb;

        public string xmlb
        {
            get { return _xmlb; }
            set { _xmlb = value; }
        }
        private string _yjqrbz;

        public string yjqrbz
        {
            get { return _yjqrbz; }
            set { _yjqrbz = value; }
        }

        private string _sybz;

        public string sybz
        {
            get { return _sybz; }
            set { _sybz = value; }
        }
        private string _yjbz;

        public string yjbz
        {
            get { return _yjbz; }
            set { _yjbz = value; }
        }
        private string _mzbz;

        public string mzbz
        {
            get { return _mzbz; }
            set { _mzbz = value; }
        }
        private string _zybz;

        public string zybz
        {
            get { return _zybz; }
            set { _zybz = value; }
        }
        private string _yzxm;

        public string yzxm
        {
            get { return _yzxm; }
            set { _yzxm = value; }
        }
        private string _zxks_id;

        public string zxks_id
        {
            get { return _zxks_id; }
            set { _zxks_id = value; }
        }
        private string _memo;

        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        private string _dydm;

        public string dydm
        {
            get { return _dydm; }
            set { _dydm = value; }
        }
        private string _ybkzbz;

        public string ybkzbz
        {
            get { return _ybkzbz; }
            set { _ybkzbz = value; }
        }
        private string _ekbz;

        public string ekbz
        {
            get { return _ekbz; }
            set { _ekbz = value; }
        }
        private string _yydm;

        public string yydm
        {
            get { return _yydm; }
            set { _yydm = value; }
        }

    }
}
