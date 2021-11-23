using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSchedule.Interface
{
    public interface IJobSettingInterface<T>
    {
        List<T> Default{get;}
        void Save();
        void Init();
        void Add(T info);
        void Delete(T info);
    }
}
