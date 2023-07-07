using Project777.Models.Entities;
using Project777.Models.ViewModels.Jobs;
using Project777.Models.ViewModels.Users;
using Project777.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Services
{
    //public class JobService : IJobService
    //{
    //    public Task<JobVM> Create(CreateJobVM jobAdd, string userId)
    //    {
    //        var jobEntity = new Job()
    //        {
    //            UserId = userId,
    //            Company = jobAdd.Company,
    //            JobTitle = jobAdd.JobTitle,
    //            JobCategoryId = jobAdd.JobCategoryId,
    //            ClosingDate = jobAdd.ClosingDate,
    //            HiringManager = jobAdd.HiringManager,
    //            Referrer = jobAdd.Referrer,
    //            Notes = jobAdd.Notes,
    //            CreatedAt = jobAdd.CreatedAt
    //        };
 
    //       //var createdJob = _userRepository.Create(userEntity);
    //       //await _userRepository.SaveChangesAsync();

    //        var model = new JobVM()
    //        {
    //            //JobId= createdJob.Id,
                
    //        };

    //        return model;

    //    }
    //}
}
