using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.Model
{
    [Serializable]
    public class KsinfoList
    {
        public bool flag { get; set; }
        public string msg { get; set; }
        public List<Ksinfo> datas { get; set; }
    }
    /// <summary>
    /// 科室信息
    /// </summary>
    [Serializable]
    public class Ksinfo
    {
        private string _id = "";

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

        private string _yydm;

        public string yydm
        {
            get { return _yydm; }
            set { _yydm = value; }
        }

        private string _yjks_id;

        public string yjks_id
        {
            get { return _yjks_id; }
            set { _yjks_id = value; }
        }

        private string _yjks_mc;

        public string yjks_mc
        {
            get { return _yjks_mc; }
            set { _yjks_mc = value; }
        }

        private string _ybks_id;

        public string ybks_id
        {
            get { return _ybks_id; }
            set { _ybks_id = value; }
        }

        private string _ybks_mc;

        public string ybks_mc
        {
            get { return _ybks_mc; }
            set { _ybks_mc = value; }
        }

        private string _ejks_id;

        public string ejks_id
        {
            get { return _ejks_id; }
            set { _ejks_id = value; }
        }

        private string _ejks_mc;

        public string ejks_mc
        {
            get { return _ejks_mc; }
            set { _ejks_mc = value; }
        }

        private string _kslb;

        public string kslb
        {
            get { return _kslb; }
            set { _kslb = value; }
        }

        private string _ksbz;

        public string ksbz
        {
            get { return _ksbz; }
            set { _ksbz = value; }
        }

        private string _cws;

        public string cws
        {
            get { return _cws; }
            set { _cws = value; }
        }


        private int _jlzt = 0;

        public int jlzt
        {
            get { return _jlzt; }
            set { _jlzt = value; }
        }

        private string _memo;

        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        private string _ekbz;

        public string ekbz
        {
            get { return _ekbz; }
            set { _ekbz = value; }
        }

        private int _zkbz;

        public int zkbz
        {
            get { return _zkbz; }
            set { _zkbz = value; }
        }


        private int _mjzbz;

        public int mjzbz
        {
            get { return _mjzbz; }
            set { _mjzbz = value; }
        }

        private int _yfbz;

        public int yfbz
        {
            get { return _yfbz; }
            set { _yfbz = value; }
        }


    }
}
