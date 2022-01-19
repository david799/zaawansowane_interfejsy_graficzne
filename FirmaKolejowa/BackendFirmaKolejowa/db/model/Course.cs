using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackendFirmaKolejowa.db.model
{
    [Table("Course")]
    public class Course
    {
        public int id { get; set; }
        [Column("train_id")]
        public int train_id { get; set; }
        [Column("ticket_price")]
        public double ticket_price { get; set; }
        [Column("costs")]
        public double costs { get; set; }
        [Column("canceled")]
        public bool canceled { get; set; }
        [Column("starts_at")]
        public DateTime starts_at { get; set; }
        [Column("ends_at")]
        public DateTime ends_at { get; set; }
        [Column("starting_point")]
        public string starting_point { get; set; }
        [Column("destination")]
        public string destination { get; set; }

    }

    public class CourseContext : DbContext
    {
        private readonly string connectionString;

        public CourseContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<Course> courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString);
        }
    }

}
