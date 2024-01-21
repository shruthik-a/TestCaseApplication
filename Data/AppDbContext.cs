using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestCaseApplication.Model;

namespace TestCaseApplication.Data
{
    
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            public DbSet<User> Users { get; set; }
            public DbSet<TestCase> TestCases { get; set; }
            public DbSet<Project> Projects { get; set; }
        }
}
