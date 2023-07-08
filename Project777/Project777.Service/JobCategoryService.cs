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
using Project777.Services.Interfaces;

namespace Project777.Services
{
    public class JobCategoryService : IJobCategoryService
    {
        private readonly IJobCategoryRepository _jobCategoryRepository;

        public JobCategoryService(IJobCategoryRepository jobCategoryRepository)
        {
            _jobCategoryRepository = jobCategoryRepository;
        }

        public async Task<JobCategoryVM> Create(CreateJobCategoryVM jobCategoryAdd)
        {

            var jobCategoryEntity = new JobCategory()
            {
                
                Name = jobCategoryAdd.Name,
            };

            _jobCategoryRepository.Create(jobCategoryEntity);
            await _jobCategoryRepository.SaveChangesAsync();

            var model = new JobCategoryVM()
            {
                Id = jobCategoryEntity.Id, 
                Name = jobCategoryEntity.Name,
            };

            return model;
        }

    }
}
