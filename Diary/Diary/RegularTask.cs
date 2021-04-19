using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    internal class RegularTask : WeeklyTask
    {
        private DateTime taskDate;
        private DateTime taskTime;
        public string TaskDate
        {
            get
            {
                if (taskDate == default(DateTime))
                {
                    return " ";
                }
                return taskDate.ToShortDateString();
            }
        }
        public string TaskTime
        {
            get
            {
                if (taskTime == default(DateTime))
                {
                    return " ";
                }
                return taskTime.ToLongTimeString();
            }
        }

        internal RegularTask(string _name) : base(_name)
        {
        }

        internal RegularTask(string _name, DateTime _dataTask, DateTime _timeTask) : base(_name)
        {
        }

        internal override string GetAlarm()
        {
            return ToString();
        }
    }
}
