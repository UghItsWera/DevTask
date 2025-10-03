using Microsoft.EntityFrameworkCore;
using VertoDevTest.Models;

namespace VertoDevTest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) {}

        public DbSet<PageSection> PageSections { get; set; }
        public DbSet<MediaItem> MediaItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PageSection>().Property(p => p.Body).HasColumnType("NVARCHAR(MAX)");
            base.OnModelCreating(modelBuilder);
        }
    }
}