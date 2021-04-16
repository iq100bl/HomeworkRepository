using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    internal class PriorityTask : RegularTask
    {
        public string priority;
        public PriorityTask(string _name) : base(_name)
        {
            name = _name;
        }
        public PriorityTask(string _name, string _priority) : base(_name)
        {
            name = _name;
            priority = _priority;
        }
        public PriorityTask(string _name, DateTime _dataTask, DateTime _timeTask) : base(_name, _dataTask, _timeTask)
        {
            name = _name;
            dataTask = _dataTask;
            timeTask = _timeTask;
        }
        public PriorityTask(string _name, DateTime _dataTask, DateTime _timeTask, string _priority) : base(_name, _dataTask, _timeTask)
        {
            name = _name;
            dataTask = _dataTask;
            timeTask = _timeTask;
            priority = _priority;
        }
        public override string GetAlarm()
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
