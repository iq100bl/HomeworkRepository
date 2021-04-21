using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    abstract public class WeeklyTask
    {
        private readonly string name;

        public string GetName()
        {
            return name;
        }
        internal abstract string GetAlarm();
        internal WeeklyTask(string _name)
        {
            name = _name;
        }
        public virtual string TaskTostring(int i)
        {
            return  $"task {i + 1} { name} ";
        }
    }
}
