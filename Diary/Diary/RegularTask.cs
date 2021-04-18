using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    internal class RegularTask : WeeklyTask
    {
        internal DateTime dataTask;
        internal DateTime timeTask;
        internal RegularTask(string _name) : base(_name)
        {
            name = _name;
        }
        internal RegularTask(string _name, DateTime _dataTask, DateTime _timeTask) :base(_name)
        {
            name = _name;
            dataTask = _dataTask;
            timeTask = _timeTask;
        }
        internal override string GetAlarm()
        {
            return ToString();
        }
    }
}
