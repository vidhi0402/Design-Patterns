﻿// <auto-generated />
using System;
using Data_Access_Layer.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data_Access_Layer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Data_Access_Layer.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("dept_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Departments");
                });

            modelBuilder.Entity("Data_Access_Layer.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<string>("Emp_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("emp_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emp_salary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("emp_status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Tbl_Employees");
                });

            modelBuilder.Entity("Data_Access_Layer.Models.Employee", b =>
                {
                    b.HasOne("Data_Access_Layer.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
