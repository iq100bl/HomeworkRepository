using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    internal class PriorityTask : RegularTask
    {
        private readonly string priority;
       
        internal PriorityTask(string _name, string _priority) : base(_name)
        {

            priority = _priority;
        }

        internal PriorityTask(string _name, DateTime _dataTask, DateTime _timeTask, string _priority) : base(_name, _dataTask, _timeTask)
        {

            priority = _priority;
        }
        public string GetPriority()
        {
            return priority;
        }
        public override string TaskTostring(int i)
        {
            var output = base.TaskTostring(i);
            if (priority != null)
            {
                output += $"{priority}";
            }
            return output;
        }

        internal override string GetAlarm()
        {
            return ToString();
        }
    }
}
