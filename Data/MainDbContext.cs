using Core.Entitites;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public class MainDbContext : System.Data.Entity.DbContext
    {
        public MainDbContext(DbContextOptions options)
        {

        }
        
        public System.Data.Entity.DbSet<Company> Companies { get; set; }
        public System.Data.Entity.DbSet<Activity> Activities { get; set; }
        public System.Data.Entity.DbSet<Education> Educations { get; set; }
        public System.Data.Entity.DbSet<Login> Logins { get; set; }
        public System.Data.Entity.DbSet<Person> People { get; set; }
        public System.Data.Entity.DbSet<Request> Requests { get; set; }

    }
}