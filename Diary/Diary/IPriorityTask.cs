using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    interface IPriorityTask : IRegularTask
    {
        public string GetPriority();

        new string TaskTostring(int i);


    }
}
