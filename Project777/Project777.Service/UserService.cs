using Project777.Models.ViewModels.Users;
using Project777.Repositories.Interfaces;
using Project777.Service.Interfaces;

namespace Project777.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<UserVM> Create(CreateUserVM userAdd)
        {
            await _uow.SaveAsync();
            var model = new UserVM();
            return model;
        }
    }
}