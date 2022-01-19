using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackendFirmaKolejowa.db.model
{
    [Table("Train")]
    public class Train
    {
        public int id { get; set; }
        [Column("is_active")]
        public bool is_active { get; set; }
        [Column("capacity")]
        public int capacity { get; set; }
    }

    public class TrainContext : DbContext
    {
        private readonly string connectionString;

        public TrainContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public TrainContext(DbContextOptions<TrainContext> options) : base(options)
        {
        }

        public DbSet<Train> trains { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(connectionString);
            }
        }
    }
}
