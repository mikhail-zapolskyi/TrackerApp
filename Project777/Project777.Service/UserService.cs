using Project777.Models.Entities;
using Project777.Models.ViewModels.Users;
using Project777.Repositories.Interfaces;
using Project777.Services.Interfaces;

namespace Project777.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository ) 
        {
           _userRepository = userRepository;
        }

        public async Task<UserVM> Create(CreateUserVM userAdd)
        {
            var userEntity = new User()
            {
                Email= userAdd.Email,
                FirstName= userAdd.FirstName,
                LastName= userAdd.LastName,
            };
 
            await _userRepository.Create(userEntity);
            
            //TODO fix the Create method so it returns the newly created user to pass to the frontend
            //For now we are just passing back the data that the frontend passed to us
                var model = new UserVM()
            {
                Email = userAdd.Email,
                FirstName = userAdd.FirstName,
                LastName = userAdd.LastName,
            };

            return model;
        }
    }
}