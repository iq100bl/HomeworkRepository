using System;
using AnaliticProgram;

public class JobSchdeduler // я реализовывал с множественными таймерами, так же парралельно попробую сделать с одним. но буду уже мучать свою реализацию
{
    private static readonly IJobs _jobs = new Jobs();   

    public static void Main()
    {
        _jobs.StartTaskLoggingTime();

        _jobs.StartTaskLoggingToFile();

        _jobs.StartTaskRecordingWebsite();

        _jobs.StartTaskLoggingToFileOnce();

        _jobs.StartCalculatingFibonacciNumbersAfterTime();


        while (true)
        {
            Console.WriteLine("Введите Y для отмены операции или другой символ для ее продолжения:");
            string s = Console.ReadLine();
            switch (s)
            {
                case "1":
                    _jobs.StopTaskLoggingTime();
                    break;
                case "2":
                    _jobs.StopTaskLoggingToFile();
                    break;
                case "3":
                    _jobs.StopTaskRecordingWebsite();
                    break;
                case "4":
                    _jobs.StopCalculatingFibonacciNumbersAfterTime();
                    break;
            }

        }

        Console.ReadKey();
    }
}

   
