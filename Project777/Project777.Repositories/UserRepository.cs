using Project777.Models.Entities;
using Project777.Repositories.Interfaces;

namespace Project777.Repositories
{
    public class UserRepository : BaseRepository<User, string, ApplicationDbContext>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}