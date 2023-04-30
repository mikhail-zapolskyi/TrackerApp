using Project777.Models.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Services.Interfaces
{
    public interface IUserService
    {
       public Task<UserVM> Create(CreateUserVM userAdd, string userId);
    }
}
