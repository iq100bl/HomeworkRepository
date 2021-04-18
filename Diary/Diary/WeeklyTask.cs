using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    abstract public class WeeklyTask
    {
        internal string name;
        internal abstract string GetAlarm();
        internal WeeklyTask(string name)
        {
        }        
    }
}
