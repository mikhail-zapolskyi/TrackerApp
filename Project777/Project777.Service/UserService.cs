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

        public async Task<UserVM> Create(CreateUserVM userAdd, string userId)
        {
            throw new Exception("Hello guys");

            var userEntity = new User()
            {
                Id = userId,
                Email= userAdd.Email,
                FirstName= userAdd.FirstName,
                LastName= userAdd.LastName,
            };
 
           _userRepository.Create(userEntity);
           await _userRepository.SaveChangesAsync();

            var model = new UserVM()
            {
                UserId= userId,
                Email = userAdd.Email,
                FirstName = userAdd.FirstName,
                LastName = userAdd.LastName,
            };

            return model;
        }

        public async Task DeleteUser(string id)
        {
            var user = await _userRepository.GetById(id);

            if(user is null)
                {
                throw new Exception($"User with {id} not found");
            }
           
            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
         
            return;
        }

    }
}