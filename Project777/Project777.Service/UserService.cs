using Project777.Models.ViewModels.Users;
using Project777.Services.Interfaces;

namespace Project777.Services
{
    public class UserService : IUserService
    {
             public async Task<UserVM> Create(CreateUserVM userAdd)
        {
            
            // this just creates a UserVM using the info from the CreateUserVM
            // no object is actually being created --- TODO add a repository layer
            var model = new UserVM()
            {
                Email= userAdd.Email,
                FirstName= userAdd.FirstName,
                LastName= userAdd.LastName,
            };

            return model;
        }
    }
}