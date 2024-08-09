using Microsoft.EntityFrameworkCore;
using UniversityBuildingService.Models;

namespace UniversityBuildingService.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UniversityBuilding> Buildings { get; set; } = null!;
        public AppDbContext(DbContextOptions options)
            : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UniversityBuilding>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.ToTable("university_building");
                entity.Property(x => x.Id).HasColumnName("id")
                    .HasDefaultValueSql("gen_random_uuid()");                    
                entity.Property(x => x.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(x => x.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");
                entity.Property(x => x.FloorsCount)
                    .HasColumnName("floors_count");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
