﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    interface IWeeklyTask
    {
        string GetName();
        string TaskTostring(int i);
    }
}
