using Project777.Models.ViewModels.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Services.Interfaces
{
    public interface IJobService
    {
        public Task<JobVM> Create(CreateJobVM jobAdd, string userId);

        public Task<ICollection<JobVM>> GetAllJobs ();
    }
}
