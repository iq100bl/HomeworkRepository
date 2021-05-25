
using System.Threading.Tasks;

namespace IJobsService
{
    public interface IJobs
    {
        Task StartJob(int jobId);

        void StopJob(int jobId);
    }
}
