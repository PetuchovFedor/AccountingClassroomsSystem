﻿// <auto-generated />
using System;
using ClassroomService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClassroomService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClassroomService.Models.AdditionalField", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("DataType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("data_type");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("additional_field", (string)null);
                });

            modelBuilder.Entity("ClassroomService.Models.Classroom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer")
                        .HasColumnName("capacity");

                    b.Property<Guid>("ClassroomTypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("id_classroom_type");

                    b.Property<int>("Floor")
                        .HasColumnType("integer")
                        .HasColumnName("floor");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<Guid>("UniversityBuildingId")
                        .HasColumnType("uuid")
                        .HasColumnName("id_university_building");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomTypeId");

                    b.HasIndex("UniversityBuildingId");

                    b.ToTable("classroom", (string)null);
                });

            modelBuilder.Entity("ClassroomService.Models.ClassroomHasAdditionalField", b =>
                {
                    b.Property<Guid>("AdditionalFieldId")
                        .HasColumnType("uuid")
                        .HasColumnName("additional_field_id");

                    b.Property<Guid>("ClassroomId")
                        .HasColumnType("uuid")
                        .HasColumnName("classroom_id");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("AdditionalFieldId", "ClassroomId");

                    b.HasIndex("ClassroomId");

                    b.ToTable("classroom_has_additional_field", (string)null);
                });

            modelBuilder.Entity("ClassroomService.Models.ClassroomType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("classroom_type", (string)null);
                });

            modelBuilder.Entity("ClassroomService.Models.UniversityBuilding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("university_building", (string)null);
                });

            modelBuilder.Entity("ClassroomService.Models.Classroom", b =>
                {
                    b.HasOne("ClassroomService.Models.ClassroomType", "ClassroomType")
                        .WithMany("Classrooms")
                        .HasForeignKey("ClassroomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassroomService.Models.UniversityBuilding", "UniversityBuilding")
                        .WithMany("Classrooms")
                        .HasForeignKey("UniversityBuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassroomType");

                    b.Navigation("UniversityBuilding");
                });

            modelBuilder.Entity("ClassroomService.Models.ClassroomHasAdditionalField", b =>
                {
                    b.HasOne("ClassroomService.Models.AdditionalField", "AdditionalField")
                        .WithMany("AdditionalFieldHasClassrooms")
                        .HasForeignKey("AdditionalFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassroomService.Models.Classroom", "Classroom")
                        .WithMany("ClassroomHasAdditionalFields")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdditionalField");

                    b.Navigation("Classroom");
                });

            modelBuilder.Entity("ClassroomService.Models.AdditionalField", b =>
                {
                    b.Navigation("AdditionalFieldHasClassrooms");
                });

            modelBuilder.Entity("ClassroomService.Models.Classroom", b =>
                {
                    b.Navigation("ClassroomHasAdditionalFields");
                });

            modelBuilder.Entity("ClassroomService.Models.ClassroomType", b =>
                {
                    b.Navigation("Classrooms");
                });

            modelBuilder.Entity("ClassroomService.Models.UniversityBuilding", b =>
                {
                    b.Navigation("Classrooms");
                });
#pragma warning restore 612, 618
        }
    }
}
