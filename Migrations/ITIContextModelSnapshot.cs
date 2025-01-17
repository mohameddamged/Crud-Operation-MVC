﻿// <auto-generated />
using MVC1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC1.Migrations
{
    [DbContext(typeof(ITIContext))]
    partial class ITIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC1.Models.Course", b =>
                {
                    b.Property<int>("Course_Id")
                        .HasColumnType("int");

                    b.Property<string>("Course_Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Course_duration")
                        .HasColumnType("int");

                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Course_Id");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("MVC1.Models.Department", b =>
                {
                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<int>("Dept_Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Dept_Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Dept_Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MVC1.Models.Student", b =>
                {
                    b.Property<int>("Std_Id")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Std_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Std_Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Std_Id");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("MVC1.Models.Course", b =>
                {
                    b.HasOne("MVC1.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVC1.Models.Student", b =>
                {
                    b.HasOne("MVC1.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVC1.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
