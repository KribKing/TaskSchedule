using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TaskSchedule.Core
{
    public class GlobalInstanceManager<T> where T : class
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
        public static T ReflectInstance(string assembly,string typename) 
        {
            Assembly assemblytask = Assembly.Load(assembly);
            Type type = assemblytask.GetType(typename);
            return Activator.CreateInstance(type) as T;
        }
    }
}
