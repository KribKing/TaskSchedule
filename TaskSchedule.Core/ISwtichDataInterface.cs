using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSchedule.Core
{
    public delegate void SwitchData<T>(T data);
    public interface ISwitchDataInterface<T> where T:class
    {
        event SwitchData<T> OnSwitchData;
    }
}
