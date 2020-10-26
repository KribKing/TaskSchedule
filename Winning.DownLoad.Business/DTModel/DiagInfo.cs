using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Business.DTModel
{
    [Serializable]
    public class DiagInfoList
    {
        public List<DiagInfo> datas { get; set; }
    }
    [Serializable]
    public class DiagInfo
    {
        private string _iICD10Id;

        public string iICD10Id
        {
            get { return _iICD10Id; }
            set { _iICD10Id = value; }
        }
        private string _cICDCode;

        public string cICDCode
        {
            get { return _cICDCode; }
            set { _cICDCode = value; }
        }
        private string _cDiagName;

        public string cDiagName
        {
            get { return _cDiagName; }
            set { _cDiagName = value; }
        }
        private string _pym;

        public string pym
        {
            get { return _pym; }
            set { _pym = value; }
        }
        private string _cDiagNameAlias;

        public string cDiagNameAlias
        {
            get { return _cDiagNameAlias; }
            set { _cDiagNameAlias = value; }
        }
        private string _pymAlias;

        public string pymAlias
        {
            get { return _pymAlias; }
            set { _pymAlias = value; }
        }
        private string _cRemark;

        public string cRemark
        {
            get { return _cRemark; }
            set { _cRemark = value; }
        }
        private int _UseFlag;

        public int useFlag
        {
            get { return _UseFlag; }
            set { _UseFlag = value; }
        }
        //private string _MappingId;

        //public string mappingId
        //{
        //    get { return _MappingId; }
        //    set { _MappingId = value; }
        //}
    }
}
