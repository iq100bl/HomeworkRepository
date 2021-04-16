using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    internal class RegularTask : WeeklyTask
    {
        public DateTime dataTask;
        public DateTime timeTask;
        public RegularTask(string _name) : base(_name)
        {
            name = _name;
            ToString();
        }
        public RegularTask(string _name, DateTime _dataTask, DateTime _timeTask) :base(_name)
        {
            name = _name;
            dataTask = _dataTask;
            timeTask = _timeTask;
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
