using Microsoft.EntityFrameworkCore;
using VertoDevTest.Models;

namespace VertoDevTest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PageSection> PageSections { get; set; }
        public DbSet<MediaItem> MediaItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure PageSection entity
            modelBuilder.Entity<PageSection>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.SectionType).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Content).HasMaxLength(2000);
                entity.Property(e => e.ImagePath).HasMaxLength(500);
                entity.HasIndex(e => e.SectionType);
                entity.HasIndex(e => e.DisplayOrder);
            });

            // Configure MediaItem entity
            modelBuilder.Entity<MediaItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.FilePath).IsRequired().HasMaxLength(500);
                entity.Property(e => e.FileType).HasMaxLength(50);
            });
        }
    }
}