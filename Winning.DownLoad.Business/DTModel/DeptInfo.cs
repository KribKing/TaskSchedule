using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.DTModel
{
    [Serializable]
    public class DeptInfoList
    {
        public List<DeptInfo> datas { get; set; }
    }
    [Serializable]
    public class DeptInfo
    {
        private int _noDept;

        public int noDept
        {
            get { return _noDept; }
            set { _noDept = value; }
        }
        private int _noDeptClinicAttr;

        public int noDeptClinicAttr
        {
            get { return _noDeptClinicAttr; }
            set { _noDeptClinicAttr = value; }
        }
        private int _noDeptInOutAttr;

        public int noDeptInOutAttr
        {
            get { return _noDeptInOutAttr; }
            set { _noDeptInOutAttr = value; }
        }
        private int _noDeptInterOrSergeryAttr;

        public int noDeptInterOrSergeryAttr
        {
            get { return _noDeptInterOrSergeryAttr; }
            set { _noDeptInterOrSergeryAttr = value; }
        }
        private string _pyCode;

        public string pyCode
        {
            get { return _pyCode; }
            set { _pyCode = value; }
        }
        private string _bStopFlag;

        public string bStopFlag
        {
            get { return _bStopFlag; }
            set { _bStopFlag = value; }
        }
        private string _iupdeptidtwo;

        public string iupdeptidtwo
        {
            get { return _iupdeptidtwo; }
            set { _iupdeptidtwo = value; }
        }
        private string _standcode;

        public string standcode
        {
            get { return _standcode; }
            set { _standcode = value; }
        }
        private string _cMDMId;

        public string cMDMId
        {
            get { return _cMDMId; }
            set { _cMDMId = value; }
        }
        private string _nohospital;

        public string nohospital
        {
            get { return _nohospital; }
            set { _nohospital = value; }
        }
        private string _nElderlyDiscountFlag;

        public string nElderlyDiscountFlag
        {
            get { return _nElderlyDiscountFlag; }
            set { _nElderlyDiscountFlag = value; }
        }
        private string _deptCode;

        public string deptCode
        {
            get { return _deptCode; }
            set { _deptCode = value; }
        }
        private string _deptName;

        public string deptName
        {
            get { return _deptName; }
            set { _deptName = value; }
        }
        private string _inputCode;

        public string inputCode
        {
            get { return _inputCode; }
            set { _inputCode = value; }
        }
        private string _deptAlias;

        public string deptAlias
        {
            get { return _deptAlias; }
            set { _deptAlias = value; }
        }
        private bool _useFlag;

        public bool useFlag
        {
            get { return _useFlag; }
            set { _useFlag = value; }
        }
    }
}
