using Project777.Models.Entities;
using Project777.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Repositories
{
    public class JobRepository: BaseRepository<Job,Guid,ApplicationDbContext>, IJobRepository
    {
        private readonly ApplicationDbContext _context;
        public JobRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
