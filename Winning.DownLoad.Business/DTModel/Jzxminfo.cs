using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.DTModel
{
    [Serializable]
    public class JzxminfoList
    {
        public bool flag { get; set; }
        public string msg { get; set; }
        public List<Jzxminfo> datas { get; set; }
    }
    [Serializable]
    public class Jzxminfo
    {
        private string _blh;

        private int _xtbz;

        public int xtbz
        {
            get { return _xtbz; }
            set { _xtbz = value; }
        }

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

        private string _yzxh;

        public string yzxh
        {
            get { return _yzxh; }
            set { _yzxh = value; }
        }

        private int _qqlx;

        public int qqlx
        {
            get { return _qqlx; }
            set { _qqlx = value; }
        }

        private int _zfbz;

        public int zfbz
        {
            get { return _zfbz; }
            set { _zfbz = value; }
        }

        private string _qqxh;

        public string qqxh
        {
            get { return _qqxh; }
            set { _qqxh = value; }
        }

        private string _qqmxxh;

        public string qqmxxh
        {
            get { return _qqmxxh; }
            set { _qqmxxh = value; }
        }
        private string _qqksdm;

        public string qqksdm
        {
            get { return _qqksdm; }
            set { _qqksdm = value; }
        }
        private string _qqksmc;

        public string qqksmc
        {
            get { return _qqksmc; }
            set { _qqksmc = value; }
        }

        private string _ysmc;

        public string ysmc
        {
            get { return _ysmc; }
            set { _ysmc = value; }
        }

        private string _qqrq;

        public string qqrq
        {
            get { return _qqrq; }
            set { _qqrq = value; }
        }

        private string _itemcode;

        public string itemcode
        {
            get { return _itemcode; }
            set { _itemcode = value; }
        }

        private string _itemname;

        public string itemname
        {
            get { return _itemname; }
            set { _itemname = value; }
        }

        private decimal _price;

        public decimal price
        {
            get { return _price; }
            set { _price = value; }
        }

        private decimal _itemqty;

        public decimal itemqty
        {
            get { return _itemqty; }
            set { _itemqty = value; }
        }

        private string _itemunit;

        public string itemunit
        {
            get { return _itemunit; }
            set { _itemunit = value; }
        }

        private string _url;

        public string url
        {
            get { return _url; }
            set { _url = value; }
        }

        private int _itemtype;

        public int itemtype
        {
            get { return _itemtype; }
            set { _itemtype = value; }
        }

        private int _sqdxh;

        public int sqdxh
        {
            get { return _sqdxh; }
            set { _sqdxh = value; }
        }

        private string _jzbz;

        public string jzbz
        {
            get { return _jzbz; }
            set { _jzbz = value; }
        }

        private string _ysdm;

        public string ysdm
        {
            get { return _ysdm; }
            set { _ysdm = value; }
        }

        private string _lrrq;

        public string lrrq
        {
            get { return _lrrq; }
            set { _lrrq = value; }
        }

        private string _qrys;

        public string qrys
        {
            get { return _qrys; }
            set { _qrys = value; }
        }

        private string _qrzt;

        public string qrzt
        {
            get { return _qrzt; }
            set { _qrzt = value; }
        }

        private string _memo;

        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        private int _spbz;

        public int spbz
        {
            get { return _spbz; }
            set { _spbz = value; }
        }

        private int _ybjszt;

        public int ybjszt
        {
            get { return _ybjszt; }
            set { _ybjszt = value; }
        }


        private string _zxksdm;

        public string zxksdm
        {
            get { return _zxksdm; }
            set { _zxksdm = value; }
        }

        private string _qrksdm;

        public string qrksdm
        {
            get { return _qrksdm; }
            set { _qrksdm = value; }
        }

        private int _sftk;

        public int sftk
        {
            get { return _sftk; }
            set { _sftk = value; }
        }

        private string _tsyfdm;

        public string tsyfdm
        {
            get { return _tsyfdm; }
            set { _tsyfdm = value; }
        }

        private int _sbid;

        public int sbid
        {
            get { return _sbid; }
            set { _sbid = value; }
        }

        private string _lcsbid;

        public string lcsbid
        {
            get { return _lcsbid; }
            set { _lcsbid = value; }
        }

        private string _sbmc;

        public string sbmc
        {
            get { return _sbmc; }
            set { _sbmc = value; }
        }

        private string _kfksmc;

        public string kfksmc
        {
            get { return _kfksmc; }
            set { _kfksmc = value; }
        }

        private int _yqrsl;

        public int yqrsl
        {
            get { return _yqrsl; }
            set { _yqrsl = value; }
        }

        private int _kqrsl;

        public int kqrsl
        {
            get { return _kqrsl; }
            set { _kqrsl = value; }
        }

        private int _cxsl;

        public int cxsl
        {
            get { return _cxsl; }
            set { _cxsl = value; }
        }

        private int _fzxh1;

        public int fzxh1
        {
            get { return _fzxh1; }
            set { _fzxh1 = value; }
        }

        private string _ypgg;

        public string ypgg
        {
            get { return _ypgg; }
            set { _ypgg = value; }
        }

        private decimal _ypjl;

        public decimal ypjl
        {
            get { return _ypjl; }
            set { _ypjl = value; }
        }

        private string _yppc;

        public string yppc
        {
            get { return _yppc; }
            set { _yppc = value; }
        }

        private int _ts;

        public int ts
        {
            get { return _ts; }
            set { _ts = value; }
        }

        private string _jldw;

        public string jldw
        {
            get { return _jldw; }
            set { _jldw = value; }
        }

        private int _ktsl;

        public int ktsl
        {
            get { return _ktsl; }
            set { _ktsl = value; }
        }

        private string _lcxmdm;

        public string lcxmdm
        {
            get { return _lcxmdm; }
            set { _lcxmdm = value; }
        }

        private string _lcxmmc;

        public string lcxmmc
        {
            get { return _lcxmmc; }
            set { _lcxmmc = value; }
        }
        public string blh
        {
            get { return _blh; }
            set { _blh = value; }
        }
        public string sfxm { get; set; }
        public string bw { get; set; }
        public string dczll { get; set; }
    }
}
