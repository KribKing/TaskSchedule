using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winning.DownLoad.Core
{
    public class GlobalInstanceManager<T>
    {
        private static T _intance;
        public static T Intance {
            get
            {
                if (_intance==null)
                {
                    _intance = Activator.CreateInstance<T>();
                }
                return _intance;
            }
            set
            {
                _intance = value;
            }
        }
    }
}
