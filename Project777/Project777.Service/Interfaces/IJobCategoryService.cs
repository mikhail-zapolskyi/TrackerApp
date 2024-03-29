﻿using Project777.Models.ViewModels.Users;
using Project777.Models.ViewModels.JobCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Services.Interfaces
{
    public interface IJobCategoryService
    {
        public Task<JobCategoryVM> Create(CreateJobCategoryVM jobCategoryAdd);

        public Task<ICollection<JobCategoryVM>> GetAllCategories();

        //public Task DeleteUser(string id);

        //public Task<UserVM> Update(UpdateUserVM data, string userId);

    }
}
