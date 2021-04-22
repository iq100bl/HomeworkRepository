using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    interface IRegularTask : IWeeklyTask
    {
        public DateTime GetDate();
        public DateTime GetTime();
        public new string TaskTostring(int i);

    }
}
