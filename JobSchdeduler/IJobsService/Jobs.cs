using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace IJobsService
{
    public class Jobs : IJobs
    {
        private static readonly CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        private readonly CancellationToken token = cancelTokenSource.Token;
        private readonly Dictionary<int, System.Timers.Timer> _timers = new Dictionary<int, System.Timers.Timer>();
<<<<<<< 01e442c8f2c436a3f92c4b334942f5ba1386bd86
        private int id;
=======
>>>>>>> Auto stash before rebase of "origin/jobScheduler"

        public async Task StartJob(int jobId)
        {
            var aTimer = new System.Timers.Timer(2000);
            bool paramReset;
            bool paramEnable;
            bool paramDelayStart;

            switch (jobId)
            {
                case 1:
                    paramReset = true;
                    paramEnable = true;
                    paramDelayStart = false;
                    break;
                case 2:
                    goto case 1;
                case 3:
                    goto case 1;
                case 4:
                    paramReset = false;
                    paramEnable = true;
                    paramDelayStart = false;
                    break;
                case 5:
                    paramReset = true;
                    paramEnable = false;
                    paramDelayStart = true;
                    break;
                default:
                    throw new InvalidOperationException("Invalid parameter type job");
            }
            //var job = ChoiceJob(jobId);
            //aTimer.Elapsed += job;
            // передавал метод для ивента через делегат, пришлось метод выбора закидывать в старт, избавился от void async, да и, наверное, ещё массивнее бы было
            switch (jobId)
            {
                case 1:
                    aTimer.Elapsed += OnTimedEvent;
                    break;
                case 2:
                    aTimer.Elapsed += RecordingOnTimerEvent;
                    break;
                case 3:
                    aTimer.Elapsed += RecordingWebsiteToFile;
                    break;
                case 4:
                    aTimer.Elapsed += RecordingOnTimerEventOnce;
                    break;
                case 5:
                    await CalculatingFibonacciNumber(token);
                    aTimer.Elapsed += FibonacciNumbers;
                    break;
                default:
                    throw new InvalidOperationException("there is no such job");
            }

<<<<<<< 01e442c8f2c436a3f92c4b334942f5ba1386bd86
            _timers.Add(id,aTimer);
            StartTimer(aTimer, paramReset, paramEnable, paramDelayStart);
            id += 1;
=======
            _timers.Add(jobId, aTimer);
            StartTimer(aTimer, paramReset, paramEnable, paramDelayStart);
>>>>>>> Auto stash before rebase of "origin/jobScheduler"
        }

        //private async void ChoiceJob(int jobId)
        //{
        //    switch (jobId)
        //    {
        //        case 1:
        //            return OnTimedEvent;
        //        case 2:
        //            return RecordingOnTimerEvent;
        //        case 3:
        //            return RecordingWebsiteToFile;
        //        case 4:
        //            return RecordingOnTimerEventOnce;
        //        case 5:
        //            await Calculatingfibonaccinumbersaftertime(token);
        //            return FibonacciNumbers;
        //        default:
        //            throw new InvalidOperationException("There is no such job");
        //    }
        //}        

        public void StopJob(int jobId)
        {
<<<<<<< 01e442c8f2c436a3f92c4b334942f5ba1386bd86
            
            _timers[jobId].Stop();

            cancelTokenSource.Cancel();
=======
            _timers[jobId].Stop();
            if (jobId == 5)
            {
                cancelTokenSource.Cancel();
            }
>>>>>>> Auto stash before rebase of "origin/jobScheduler"
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

        private static async Task CalculatingFibonacciNumber(CancellationToken token)
        {
            try
            {
                uint n1 = 1;
                uint n2 = 2;
                await Task.Run(() =>
                {
                    while (true)
                    {
                        checked
                        {
                            n1 += n2;
                            n2 += n1;
                            if (token == cancelTokenSource.Token)
                            {
                                    Console.WriteLine("Fibonacci current number: " + n2);
                            }
                        }
                        Thread.Sleep(1000);
                    }
                }, token);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void FibonacciNumbers(object source, ElapsedEventArgs e)
        {
            cancelTokenSource.Cancel();
        }

        //private void calculatingfibonaccinumbersaftertime(object source, elapsedeventargs e)
        //{
        //    var numberfibonacci = fibonaccinumbers(token);
        //    console.writeline("at the moment the fibonacci number is: "+ numberfibonacci);
        //}

        private static void StartTimer(System.Timers.Timer _timer, bool reset, bool enable, bool delayStart)
        {
            if (delayStart == true)
            {
                _ = new Task(async () => 
                {
                    enable = true;
                    await Task.Delay(5000);                    
                });

            }
            _timer.AutoReset = reset;
            _timer.Enabled = enable;
        }
    }
}

