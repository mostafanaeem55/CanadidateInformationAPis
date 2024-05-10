using CanadidateInformationAPis.Models;
using Microsoft.EntityFrameworkCore;

namespace CanadidateInformationAPis.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        public DbSet<CanadidateInfo> canadidateInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CanadidateInfo>()
                .HasKey(c => c.Email);

        }
    }
}
