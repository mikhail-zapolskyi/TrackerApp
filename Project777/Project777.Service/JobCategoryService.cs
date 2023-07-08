using Project777.Models.Entities;
using Project777.Models.ViewModels.Users;
using Project777.Models.ViewModels.JobCategories;
using Project777.Repositories;
using Project777.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Services
{
    public class JobCategoryService
    {
        private readonly IJobCategoryRepository _jobCategoryRepository;

        public JobCategoryService(IJobCategoryRepository jobCategoryRepository)
        {
            _jobCategoryRepository = jobCategoryRepository;
        }

        public async Task<JobCategoryVM> Create(CreateJobCategoryVM jobCategoryAdd, string userId)
        {

            var JobCategoryEntity = new JobCategory()
            {
                Id = userId,
                Name = jobCategoryAdd.Name,
            };

            _jobCategoryRepository.Create(JobCategoryEntity);
            await _jobCategoryRepository.SaveChangesAsync();

            var model = new JobCategoryVM()
            {
                Id = userId,
                Name = jobCategoryAdd.Name,
            };

            return model;
        }

    }
}
