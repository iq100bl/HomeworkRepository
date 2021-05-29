using System;
using System.Threading;
using System.Threading.Tasks;
using IJobsService;

public class JobSchdeduler // я реализовывал с множественными таймерами, так же парралельно попробую сделать с одним. но буду уже мучать свою реализацию
{
    private static readonly IJobs _jobs = new Jobs();
    public static void Main()
    {
        while (true)
        {
            int Startstop = Convert.ToInt32(Console.ReadLine());
            if (Startstop == 1)
            {
                int id = Convert.ToInt32(Console.ReadLine());
                Task.Run(() => _jobs.StartJob(id));
            }
            else if (Startstop == 2)
            {
                int id = Convert.ToInt32(Console.ReadLine());
                _jobs.StopJob(id);
            }
        }
    }
}

   
