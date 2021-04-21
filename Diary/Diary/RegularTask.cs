using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    internal class RegularTask : WeeklyTask
    {
        private readonly DateTime taskDate;
        private readonly DateTime taskTime;

        internal RegularTask(string _name) : base(_name)
        {
        }

        internal RegularTask(string _name, DateTime _dataTask, DateTime _timeTask) : base(_name)
        {
            taskDate = _dataTask;
            taskTime = _timeTask;
        }
        public DateTime GetDate()
        {
            return taskDate;
        }
        public DateTime GetTime()
        {
            return taskTime;
        }

        internal override string GetAlarm()
        {
            return ToString();
        }
        public override string TaskTostring(int i)
        {
            var output = base.TaskTostring(i);
            if (taskDate != default)
            {
                output += $"{taskDate.ToShortDateString()} ";
            }

            if (taskTime != default)
            {
                output += $"{taskTime.ToLongTimeString()} ";
            }
            return output;
        }
    }
}
