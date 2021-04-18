using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    internal class PriorityTask : RegularTask
    {
        internal string priority;

        internal PriorityTask(string _name) : base(_name)
        {
            name = _name;
        }

        internal PriorityTask(string _name, string _priority) : base(_name)
        {
            name = _name;
            priority = _priority;
        }

        internal PriorityTask(string _name, DateTime _dataTask, DateTime _timeTask) : base(_name, _dataTask, _timeTask)
        {
            name = _name;
            dataTask = _dataTask;
            timeTask = _timeTask;
        }

        internal PriorityTask(string _name, DateTime _dataTask, DateTime _timeTask, string _priority) : base(_name, _dataTask, _timeTask)
        {
            name = _name;
            dataTask = _dataTask;
            timeTask = _timeTask;
            priority = _priority;
        }

        internal override string GetAlarm()
        {
            return ToString();
        }

        public override string ToString()
        {
            TimeSpan before = dataTask - DateTime.Now;
            int days = (int)before.TotalDays;
            if (days > 0)
            {
                Console.WriteLine(" before the task :" + days);
                return null;
            }
            else
            {
                Console.WriteLine("task day has already passed");
                return null;
            }
        }
    }
}
