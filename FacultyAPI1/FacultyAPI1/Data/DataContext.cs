using FacultyAPI1.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyAPI1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Faculty> Faculties { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DUTValues;Trusted_Connection=true;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Faculty>().HasData(
                new Faculty { FacultyId = 1, FacultyName = "Accounting and Informatics" },
                new Faculty { FacultyId = 2, FacultyName = "Applied Sciences" },
                new Faculty { FacultyId = 3, FacultyName = "Management Sciences" },
                new Faculty { FacultyId = 4, FacultyName = "Engineering and the Built Environment" },
                new Faculty { FacultyId = 5, FacultyName = "Health Sciences" },
                new Faculty { FacultyId = 6, FacultyName = "Arts and Design" }
            );
        }

    }
}
