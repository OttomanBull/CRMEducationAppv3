using Core.Entitites;
using Microsoft.EntityFrameworkCore;

namespace CRM_API.Repositories
{
    public class RepositoryContext :DbContext
    {
        public RepositoryContext(DbContextOptions options):
            base(options)
        {

        }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Request> Requests { get; set; }

    }
}
