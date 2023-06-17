using Project777.Models.Entities;
using Project777.Models.ViewModels.Users;
using Project777.Repositories.Interfaces;
using Project777.Services.Interfaces;
using Project777.Shared.Exceptions;

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
            //throw new NotFoundException("Hello guys");

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


        public async Task<UserVM> Update(UpdateUserVM userUpdate, string userId)
        {
            var userEntity = await _userRepository.GetById(userId);
            //userEntity.Email = userUpdate.Email;
            userEntity.FirstName = userUpdate.FirstName;
            userEntity.LastName = userUpdate.LastName;
            _userRepository.Update(userEntity);
            await _userRepository.SaveChangesAsync();

            var model = new UserVM()
            {
                UserId = userId,
                Email = userEntity.Email,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
            };
            return model;



        }


    }
}