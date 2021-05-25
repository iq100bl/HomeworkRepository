using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliticProgram
{
    public interface IJobs
    {
        void StartTaskLoggingTime();

        void StartTaskLoggingToFile();

        void StartTaskRecordingWebsite();

        void StartTaskLoggingToFileOnce();

        void StartCalculatingFibonacciNumbersAfterTime();

        void StopTaskLoggingTime();

        void StopTaskLoggingToFile();

        void StopTaskRecordingWebsite();

        void StopTaskLoggingToFileOnce();

        void StopCalculatingFibonacciNumbersAfterTime();
    }
}
