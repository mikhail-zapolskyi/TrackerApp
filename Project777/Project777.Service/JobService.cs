using Project777.Models.Entities;
using Project777.Models.ViewModels.JobCategories;
using Project777.Models.ViewModels.Jobs;
using Project777.Models.ViewModels.Users;
using Project777.Repositories;
using Project777.Repositories.Interfaces;
using Project777.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository )
        {
           _jobRepository = jobRepository;
        }
        public async Task<JobVM> Create(CreateJobVM jobAdd, string userId)
        {
            var jobEntity = new Job()
            {
                UserId = userId,
                Company = jobAdd.Company,
                JobTitle = jobAdd.JobTitle,
                JobCategoryId = jobAdd.JobCategoryId,
                ClosingDate = jobAdd.ClosingDate,
                HiringManager = jobAdd.HiringManager,
                Referrer = jobAdd.Referrer,
                Notes = jobAdd.Notes,
                CreatedAt = DateTime.UtcNow
            };

            _jobRepository.Create(jobEntity);
            await _jobRepository.SaveChangesAsync();
            var model = new JobVM()
            {
                //JobId= createdJob.Id,
                Company = jobAdd.Company,
                JobTitle = jobAdd.JobTitle,
                JobCategoryId = jobAdd.JobCategoryId,
                ClosingDate = jobAdd.ClosingDate,
                HiringManager = jobAdd.HiringManager,
                Referrer = jobAdd.Referrer,
                Notes = jobAdd.Notes,
                CreatedAt = jobEntity.CreatedAt

            };

            return model;

        }

        public async Task DeleteJob(Guid id)
        {
            var job = await _jobRepository.GetById(id);

            if(job is null)
                {
                throw new Exception($"Job with {id} not found");
            }
           
            _jobRepository.Delete(job);
            await _jobRepository.SaveChangesAsync();
         
            return;
        }


        public async Task<JobVM> Update(UpdateJobVM jobUpdate, Guid jobId)
        {
            var jobEntity = await _jobRepository.GetById(jobId);
            //userEntity.Email = userUpdate.Email;
            jobEntity.Company = jobUpdate.Company;
            jobEntity.JobTitle = jobUpdate.JobTitle;
            jobEntity.ClosingDate = jobUpdate.ClosingDate;
            jobEntity.HiringManager = jobUpdate.HiringManager;
            jobEntity.Referrer = jobUpdate.Referrer;
            jobEntity.Notes = jobUpdate.Notes;
            await _jobRepository.SaveChangesAsync();

            var model = new JobVM()
            {
                JobId = jobId,
                Company = jobEntity.Company,
                JobTitle = jobEntity.JobTitle,
                ClosingDate = jobEntity.ClosingDate,
                HiringManager = jobEntity.HiringManager,
                Referrer = jobEntity.Referrer,
                Notes = jobEntity.Notes,
            };
            return model;



        }

        public async Task<ICollection<JobVM>>GetAllJobs()
        {

            var jobs =  await _jobRepository.GetAll();

            List<JobVM> response = new List<JobVM>();

            foreach (var job in jobs)
            {

                var model = new JobVM()
                {
                    JobId = job.Id,
                    Company = job.Company,
                    JobTitle = job.JobTitle,
                    JobCategoryId = job.JobCategoryId,
                    ClosingDate = job.ClosingDate,
                    HiringManager = job.HiringManager,
                    Referrer = job.Referrer,
                    Notes = job.Notes,
                    CreatedAt = job.CreatedAt,
                };
                response.Add(model);
            }
            return response;
        }
    }
}
