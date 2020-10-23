using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.Model
{
    [Serializable]
    public class ZginfoList
    {
        public bool flag { get; set; }
        public string msg { get; set; }
        public List<Zginfo> datas { get; set; }
    }
    /// <summary>
    /// 职工信息
    /// </summary>
    [Serializable]
    public class Zginfo
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
        private string _sex;

        public string sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        private string _birth;

        public string birth
        {
            get { return _birth; }
            set { _birth = value; }
        }
        private string _hyzk;

        public string hyzk
        {
            get { return _hyzk; }
            set { _hyzk = value; }
        }
        private string _sfzh;

        public string sfzh
        {
            get { return _sfzh; }
            set { _sfzh = value; }
        }
        private string _ks_id;

        public string ks_id
        {
            get { return _ks_id; }
            set { _ks_id = value; }
        }
        private string _ks_mc;

        public string ks_mc
        {
            get { return _ks_mc; }
            set { _ks_mc = value; }
        }
        private string _bq_id;

        public string bq_id
        {
            get { return _bq_id; }
            set { _bq_id = value; }
        }
        private string _bq_mc;

        public string bq_mc
        {
            get { return _bq_mc; }
            set { _bq_mc = value; }
        }

        private string _zglb;

        public string zglb
        {
            get { return _zglb; }
            set { _zglb = value; }
        }
        private string _zc_id;

        public string zc_id
        {
            get { return _zc_id; }
            set { _zc_id = value; }
        }
        private string _zc_mc;

        public string zc_mc
        {
            get { return _zc_mc; }
            set { _zc_mc = value; }
        }
        private string _cfbz;

        public string cfbz
        {
            get { return _cfbz; }
            set { _cfbz = value; }
        }

        private string _jlzt;

        public string jlzt
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
    }
}
