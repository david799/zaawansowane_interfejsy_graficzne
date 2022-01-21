using BackendFirmaKolejowa.db.model;
using Microsoft.EntityFrameworkCore;

namespace BackendFirmaKolejowa.db.repository
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Course> courses { get; set; }
        public DbSet<Train> trains { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<User> users { get; set; }


    }
}
