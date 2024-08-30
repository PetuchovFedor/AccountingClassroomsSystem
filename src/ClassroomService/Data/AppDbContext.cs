using ClassroomService.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassroomService.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UniversityBuilding> Buildings { get; set; } = null!;
        public DbSet<ClassroomType> ClassroomTypes { get; set; } = null!;
        public DbSet<Classroom> Classrooms { get; set; } = null!;
        public DbSet<AdditionalField> AdditionalFields { get; set; } = null!;
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
                entity.Property(x => x.Id).HasColumnName("id");                    
                entity.Property(x => x.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.HasMany(x => x.Classrooms)
                    .WithOne(x => x.UniversityBuilding!)
                    .HasForeignKey(x => x.UniversityBuildingId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<ClassroomType>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.ToTable("classroom_type");
                entity.Property(x => x.Id).HasColumnName("id")
                    .HasDefaultValueSql("gen_random_uuid()");
                entity.Property(x => x.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.HasMany(x => x.Classrooms)
                    .WithOne(x => x.ClassroomType!)
                    .HasForeignKey(x => x.ClassroomTypeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.ToTable("classroom");
                entity.Property(x => x.Id).HasColumnName("id")
                    .HasDefaultValueSql("gen_random_uuid()");
                entity.Property(x => x.Name)
                     .HasMaxLength(255)
                     .HasColumnName("name");
                entity.Property(x => x.Capacity)
                    .HasColumnName("capacity");
                entity.Property(x => x.Number)
                    .HasColumnName("number");
                entity.Property(x => x.Floor)
                    .HasColumnName("floor");
                entity.Property(x => x.ClassroomTypeId)
                    .HasColumnName("id_classroom_type");
                entity.Property(x => x.UniversityBuildingId)
                    .HasColumnName("id_university_building");
                entity.HasOne(x => x.ClassroomType)
                    .WithMany(x => x.Classrooms)
                    .HasForeignKey(x => x.ClassroomTypeId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(x => x.UniversityBuilding)
                    .WithMany(x => x.Classrooms)
                    .HasForeignKey(x => x.UniversityBuildingId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(x => x.AdditionalFields)
                    .WithMany(y => y.Classrooms)
                    .UsingEntity<ClassroomHasAdditionalField>(
                        z => z
                            .HasOne(x => x.AdditionalField)
                            .WithMany(y => y.AdditionalFieldHasClassrooms)
                            .HasForeignKey(x => x.AdditionalFieldId),
                        z => z
                            .HasOne(x => x.Classroom)
                            .WithMany(y => y.ClassroomHasAdditionalFields)
                            .HasForeignKey(x => x.ClassroomId),
                        z =>
                        {
                            z.HasKey(x => new { x.AdditionalFieldId, x.ClassroomId });
                            z.ToTable("classroom_has_additional_field");
                            z.Property(x => x.Value).HasColumnName("value");
                            z.Property(x => x.AdditionalFieldId)
                                .HasColumnName("additional_field_id");
                            z.Property(x => x.ClassroomId)
                                .HasColumnName("classroom_id");
                        });                                                  
            });
            modelBuilder.Entity<AdditionalField>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.ToTable("additional_field");
                entity.Property(x => x.Id).HasColumnName("id")
                    .HasDefaultValueSql("gen_random_uuid()");
                entity.Property(x => x.Name)
                     .HasMaxLength(255)
                     .HasColumnName("name");
                entity.Property(x => x.DataType)
                     .HasMaxLength(255)
                     .HasColumnName("data_type");
                entity.HasMany(x => x.Classrooms)
                    .WithMany(y => y.AdditionalFields)
                    .UsingEntity<ClassroomHasAdditionalField>(
                        z => z
                            .HasOne(x => x.Classroom)
                            .WithMany(y => y.ClassroomHasAdditionalFields)
                            .HasForeignKey(x => x.ClassroomId),
                        z => z
                            .HasOne(x => x.AdditionalField)
                            .WithMany(y => y.AdditionalFieldHasClassrooms)
                            .HasForeignKey(x => x.AdditionalFieldId),
                        z =>
                        {
                            z.HasKey(x => new { x.AdditionalFieldId, x.ClassroomId });
                            z.ToTable("classroom_has_additional_field");
                            z.Property(x => x.Value).HasColumnName("value");
                            z.Property(x => x.AdditionalFieldId)
                                .HasColumnName("additional_field_id");
                            z.Property(x => x.ClassroomId)
                                .HasColumnName("classroom_id");
                        });
            });
        }
    }
}
