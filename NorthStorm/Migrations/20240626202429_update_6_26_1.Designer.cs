﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NorthStorm.Data;

#nullable disable

namespace NorthStorm.Migrations
{
    [DbContext(typeof(NorthStormContext))]
    [Migration("20240626202429_update_6_26_1")]
    partial class update_6_26_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeJobTransfer", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("JobTransfersId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "JobTransfersId");

                    b.HasIndex("JobTransfersId");

                    b.ToTable("EmployeeJobTransfer");
                });

            modelBuilder.Entity("EmployeeRecruitment", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("RecruitmentsId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "RecruitmentsId");

                    b.HasIndex("RecruitmentsId");

                    b.ToTable("EmployeeRecruitment");
                });

            modelBuilder.Entity("NorthStorm.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CivilNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FourthName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("IBAN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherMiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationalityId")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("ReligionId")
                        .HasColumnType("int");

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("RaceId");

                    b.HasIndex("ReligionId");

                    b.HasIndex("StateId");

                    b.HasIndex("StatusId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("NorthStorm.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("NorthStorm.Models.JobTransfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ReferenceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReferenceNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransferFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransferTo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobTransfers");
                });

            modelBuilder.Entity("NorthStorm.Models.Nationality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("NorthStorm.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("NorthStorm.Models.Recruitment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ReferenceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReferenceNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Recruitments");
                });

            modelBuilder.Entity("NorthStorm.Models.Religion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Religiones");
                });

            modelBuilder.Entity("NorthStorm.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("NorthStorm.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("EmployeeJobTransfer", b =>
                {
                    b.HasOne("NorthStorm.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NorthStorm.Models.JobTransfer", null)
                        .WithMany()
                        .HasForeignKey("JobTransfersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeRecruitment", b =>
                {
                    b.HasOne("NorthStorm.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NorthStorm.Models.Recruitment", null)
                        .WithMany()
                        .HasForeignKey("RecruitmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NorthStorm.Models.Employee", b =>
                {
                    b.HasOne("NorthStorm.Models.Gender", "gender")
                        .WithMany("Employees")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NorthStorm.Models.Nationality", "nationality")
                        .WithMany("Employees")
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NorthStorm.Models.Race", "race")
                        .WithMany("Employees")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NorthStorm.Models.Religion", "religion")
                        .WithMany("Employees")
                        .HasForeignKey("ReligionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NorthStorm.Models.State", "State")
                        .WithMany("Employees")
                        .HasForeignKey("StateId");

                    b.HasOne("NorthStorm.Models.Status", "status")
                        .WithMany("Employees")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");

                    b.Navigation("gender");

                    b.Navigation("nationality");

                    b.Navigation("race");

                    b.Navigation("religion");

                    b.Navigation("status");
                });

            modelBuilder.Entity("NorthStorm.Models.Recruitment", b =>
                {
                    b.HasOne("NorthStorm.Models.State", null)
                        .WithMany("Recruitments")
                        .HasForeignKey("StateId");
                });

            modelBuilder.Entity("NorthStorm.Models.Gender", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("NorthStorm.Models.Nationality", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("NorthStorm.Models.Race", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("NorthStorm.Models.Religion", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("NorthStorm.Models.State", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Recruitments");
                });

            modelBuilder.Entity("NorthStorm.Models.Status", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}