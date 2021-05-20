using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace AnaliticProgram
{
    public class Jobs : IJobs
    {
        private static List<System.Timers.Timer> listTimers = new List<System.Timers.Timer>();
        private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        private CancellationToken token = cancelTokenSource.Token;
        public void StartTaskLoggingTime()
        {
            var aTimer = new System.Timers.Timer(2000);
            var paramReset = true;
            var paramEnable = true;
            aTimer.Elapsed += OnTimedEvent;
            listTimers[0] = aTimer;
            StartTimer(aTimer, paramReset, paramEnable);

        }

        public void StartTaskLoggingToFile()
        {
            var aTimer = new System.Timers.Timer(2000);
            var paramReset = true;
            var paramEnable = true;
            aTimer.Elapsed += RecordingOnTimerEvent;
            listTimers[1] = aTimer;
            StartTimer(aTimer, paramReset, paramEnable);
        }

        public void StartTaskRecordingWebsite()
        {
            var aTimer = new System.Timers.Timer(2000);
            var paramReset = true;
            var paramEnable = true;
            aTimer.Elapsed += RecordingWebsiteToFile;
            listTimers[2] = aTimer;
            StartTimer(aTimer, paramReset, paramEnable);
        }

        public void StartTaskLoggingToFileOnce()
        {
            var aTimer = new System.Timers.Timer(2000);
            var paramReset = false;
            var paramEnable = true;
            aTimer.Elapsed += RecordingOnTimerEventOnce;
            listTimers[3] = aTimer;
            StartTimer(aTimer, paramReset, paramEnable);
        }
        public void StartCalculatingFibonacciNumbersAfterTime()
        {
            var aTimer = new System.Timers.Timer(2000);
            var paramReset = true;
            var paramEnable = false;
            aTimer.Elapsed += CalculatingFibonacciNumbersAfterTime;
            listTimers[4] = aTimer;
            _ = new Task(async () => //делала специально через дилей, чтобы вычисления начались, а таймер был отложен
              {
                  paramEnable = true;
                  await Task.Delay(5000);
                  StartTimer(aTimer, paramReset, paramEnable);
              });

            FibonacciNumbers(token).Start();
        }

        public void StopTaskLoggingTime()
        {
            listTimers [0].Stop();
        }

        public void StopTaskLoggingToFile()
        {
            listTimers[1].Stop();
        }

        public void StopTaskRecordingWebsite()
        {
            listTimers[2].Stop();
        }

        public void StopTaskLoggingToFileOnce()
        {
            listTimers[3].Stop();
        }
        public void StopCalculatingFibonacciNumbersAfterTime()
        {
            listTimers[4].Stop();
            cancelTokenSource.Cancel();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }

        private static void RecordingOnTimerEvent(object source, ElapsedEventArgs e)
        {
            string writePath = @"D:\for training\HomeworkRepository\JobSchdeduler\logtime.txt";
            string text = ("File write event was raised at {0:HH:mm:ss.fff}", e.SignalTime).ToString();

            try
            {
                using (var sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }

        private void RecordingOnTimerEventOnce(object source, ElapsedEventArgs e)
        {
            string writePath = @"D:\for training\HomeworkRepository\JobSchdeduler\logtimeOnce.txt";
            string text = ("One-time File Write Event occurred in {0:HH:mm:ss.fff}", e.SignalTime).ToString();
            try
            {
                using (var sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
            finally
            {
                StopTaskLoggingToFileOnce();
            }
        }

        private static void RecordingWebsiteToFile(object source, ElapsedEventArgs e)
        {
            var wc = new WebClient();
            string text = wc.DownloadString("https://mail.ru/");
            string writePath = @"D:\for training\HomeworkRepository\JobSchdeduler\website.txt";

            try
            {
                using (var sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }

        private static async Task<uint> FibonacciNumbers(CancellationToken token)
        {
            try
            {
                uint n1 = 1;
                uint n2 = 2;
                await new Task(() =>
                {
                    n1 += checked(n2);
                    n2 += checked(n1);
                    Thread.Sleep(1000);
                });

                if (cancelTokenSource.IsCancellationRequested)
                {
                    Console.WriteLine("Fibonacci calculation interrupted, current number: " + n2);
                }
                return n2;
            }
            catch (OverflowException ex)
            {
                 Console.WriteLine(ex.Message);
                return 0;
            }
        }

        private void CalculatingFibonacciNumbersAfterTime(object source, ElapsedEventArgs e)
        {
            var numberFibonacci = FibonacciNumbers(token);
            Console.WriteLine("At the moment the fibonacci number is: "+ numberFibonacci);
        }

        private static void StartTimer(System.Timers.Timer _timer, bool reset, bool enable)
        {
            _timer.AutoReset = reset;
            _timer.Enabled = enable;
        }
    }
}

