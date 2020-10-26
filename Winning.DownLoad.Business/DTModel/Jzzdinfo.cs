using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.DTModel
{
    [Serializable]
    public class JzzdinfoList
    {
        public bool flag { get; set; }
        public string msg { get; set; }
        public List<Jzzdinfo> datas { get; set; }
    }
    [Serializable]
    public class Jzzdinfo
    {
        private string _patid;

        public string patid
        {
            get { return _patid; }
            set { _patid = value; }
        }
        private int _xtbz;

        public int xtbz
        {
            get { return _xtbz; }
            set { _xtbz = value; }
        }
        private int _ghxh;

        public int ghxh
        {
            get { return _ghxh; }
            set { _ghxh = value; }
        }
        private int _syxh;

        public int syxh
        {
            get { return _syxh; }
            set { _syxh = value; } 
        }
        private int _zdlx;

        public int zdlx
        {
            get { return _zdlx; }
            set { _zdlx = value; }
        }
        private int _zdlb;

        public int zdlb
        {
            get { return _zdlb; }
            set { _zdlb = value; }
        }
        private string _ysdm;

        public string ysdm
        {
            get { return _ysdm; }
            set { _ysdm = value; }
        }
        private string _ysmc;

        public string ysmc
        {
            get { return _ysmc; }
            set { _ysmc = value; }
        }
        private string _zddm;

        public string zddm
        {
            get { return _zddm; }
            set { _zddm = value; }
        }
        private string _zdmc;

        public string zdmc
        {
            get { return _zdmc; }
            set { _zdmc = value; }
        }
        private string _lrrq;

        public string lrrq
        {
            get { return _lrrq; }
            set { _lrrq = value; }
        }
        private string _memo;

        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
    }
}



