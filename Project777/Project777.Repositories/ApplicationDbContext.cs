using Microsoft.EntityFrameworkCore;
using Project777.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project777.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();
        public DbSet<JobCategory> JobCategories => Set<JobCategory>();

    }
}
