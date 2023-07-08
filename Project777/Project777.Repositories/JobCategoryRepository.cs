using Project777.Models.Entities;
using Project777.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Repositories
{
    public class JobCategoryRepository : BaseRepository<JobCategory, Guid, ApplicationDbContext>, IJobCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public JobCategoryRepository(ApplicationDbContext context) : base(context) 
        { 
            _context = context; 
        }
    }
}
