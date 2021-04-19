using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    internal class PriorityTask : RegularTask
    {
        private string priority;
        public string Priority
        {
            get
            {
                return priority;
            }
        }

        internal PriorityTask(string _name) : base(_name)
        {
        }

        internal PriorityTask(string _name, string _priority) : base(_name)
        {

            priority = _priority;
        }

        internal PriorityTask(string _name, DateTime _dataTask, DateTime _timeTask) : base(_name, _dataTask, _timeTask)
        {
        }

        internal PriorityTask(string _name, DateTime _dataTask, DateTime _timeTask, string _priority) : base(_name, _dataTask, _timeTask)
        {

            priority = _priority;
        }

        internal override string GetAlarm()
        {
            return ToString();
        }
    }
}
