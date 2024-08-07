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
    [Migration("20240706004902_AddCascadeToJobTransfers")]
    partial class AddCascadeToJobTransfers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CertificateEmployee", b =>
                {
                    b.Property<int>("CertificatesId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.HasKey("CertificatesId", "EmployeesId");

                    b.HasIndex("EmployeesId");

                    b.ToTable("CertificateEmployee", (string)null);
                });

            modelBuilder.Entity("EmployeeJobTransfer", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("JobTransfersId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "JobTransfersId");

                    b.HasIndex("JobTransfersId");

                    b.ToTable("EmployeeJobTransfer", (string)null);
                });

            modelBuilder.Entity("EmployeeLevel", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("LevelsId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "LevelsId");

                    b.HasIndex("LevelsId");

                    b.ToTable("EmployeeLevel", (string)null);
                });

            modelBuilder.Entity("EmployeePromotion", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("PromotionsId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "PromotionsId");

                    b.HasIndex("PromotionsId");

                    b.ToTable("EmployeePromotion", (string)null);
                });

            modelBuilder.Entity("EmployeeSalary", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("SalariesId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "SalariesId");

                    b.HasIndex("SalariesId");

                    b.ToTable("EmployeeSalary", (string)null);
                });

            modelBuilder.Entity("JobTitleLevel", b =>
                {
                    b.Property<int>("JobTitlesId")
                        .HasColumnType("int");

                    b.Property<int>("LevelsId")
                        .HasColumnType("int");

                    b.HasKey("JobTitlesId", "LevelsId");

                    b.HasIndex("LevelsId");

                    b.ToTable("JobTitleLevel", (string)null);
                });

            modelBuilder.Entity("NorthStorm.Models.Assistants.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccurateSpecialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GlobalSpecialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UniversityId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("NorthStorm.Models.Assistants.GovernmentalInstitute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClassificationId")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentGovernmentalInstituteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassificationId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ParentGovernmentalInstituteId");

                    b.ToTable("GovernmentalInstitutes");
                });

            modelBuilder.Entity("NorthStorm.Models.Assistants.GovernmentalInstituteClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GovernmentalInstituteClassification");
                });

            modelBuilder.Entity("NorthStorm.Models.Assistants.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnnualBonus")
                        .HasColumnType("int");

                    b.Property<string>("GradeAsWriting")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("GradeNumber")
                        .HasColumnType("int");

                    b.Property<int>("MinimumDuration")
                        .HasColumnType("int");

                    b.Property<int>("Stage01")
                        .HasColumnType("int");

                    b.Property<int>("Stage02")
                        .HasColumnType("int");

                    b.Property<int>("Stage03")
                        .HasColumnType("int");

                    b.Property<int>("Stage04")
                        .HasColumnType("int");

                    b.Property<int>("Stage05")
                        .HasColumnType("int");

                    b.Property<int>("Stage06")
                        .HasColumnType("int");

                    b.Property<int>("Stage07")
                        .HasColumnType("int");

                    b.Property<int>("Stage08")
                        .HasColumnType("int");

                    b.Property<int>("Stage09")
                        .HasColumnType("int");

                    b.Property<int>("Stage10")
                        .HasColumnType("int");

                    b.Property<int>("Stage11")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("NorthStorm.Models.Assistants.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentLevelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("ParentLevelId");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("NorthStorm.Models.Assistants.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("LocationClassificationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentLocationId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationClassificationId");

                    b.HasIndex("ParentLocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("NorthStorm.Models.Assistants.State", b =>
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

            modelBuilder.Entity("NorthStorm.Models.Assistants.Status", b =>
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

            modelBuilder.Entity("NorthStorm.Models.Classifications.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BaghdadSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KirkukSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("NorthStorm.Models.Classifications.JobTitleClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BaghdadSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KirkukSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobTitleClassifications");
                });

            modelBuilder.Entity("NorthStorm.Models.Classifications.LocationClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BaghdadSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KirkukSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LocationClassifications");
                });

            modelBuilder.Entity("NorthStorm.Models.Classifications.Nationality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BaghdadSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KirkukSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("NorthStorm.Models.Classifications.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BaghdadSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KirkukSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("NorthStorm.Models.Classifications.Religion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BaghdadSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KirkukSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Religions");
                });

            modelBuilder.Entity("NorthStorm.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CivilNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FourthName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("IBAN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherMiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NationalityId")
                        .HasColumnType("int");

                    b.Property<int?>("RaceId")
                        .HasColumnType("int");

                    b.Property<int?>("RecruitmentId")
                        .HasColumnType("int");

                    b.Property<int?>("ReligionId")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("RaceId");

                    b.HasIndex("RecruitmentId");

                    b.HasIndex("ReligionId");

                    b.HasIndex("StatusId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("NorthStorm.Models.EmployeeJobTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JobTitleAssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReferenceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReferenceNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("JobTitleId");

                    b.ToTable("EmployeeJobTitles");
                });

            modelBuilder.Entity("NorthStorm.Models.JobTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClassificationId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GradeId")
                        .HasColumnType("int");

                    b.Property<int?>("JobTitleClassificationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentJobTitleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassificationId");

                    b.HasIndex("GradeId");

                    b.HasIndex("JobTitleClassificationId");

                    b.HasIndex("ParentJobTitleId");

                    b.ToTable("JobTitles");
                });

            modelBuilder.Entity("NorthStorm.Models.JobTransfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DestinationLevelId")
                        .HasColumnType("int");

                    b.Property<int?>("LevelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReferenceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReferenceNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DestinationLevelId");

                    b.HasIndex("LevelId");

                    b.ToTable("JobTransfers");
                });

            modelBuilder.Entity("NorthStorm.Models.Promotion", b =>
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

                    b.HasKey("Id");

                    b.ToTable("Promotions");
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

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recruitments");
                });

            modelBuilder.Entity("NorthStorm.Models.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BasicSalary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Salary");
                });

            modelBuilder.Entity("CertificateEmployee", b =>
                {
                    b.HasOne("NorthStorm.Models.Assistants.Certificate", null)
                        .WithMany()
                        .HasForeignKey("CertificatesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NorthStorm.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeJobTransfer", b =>
                {
                    b.HasOne("NorthStorm.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NorthStorm.Models.JobTransfer", null)
                        .WithMany()
                        .HasForeignKey("JobTransfersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeLevel", b =>
                {
                    b.HasOne("NorthStorm.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NorthStorm.Models.Assistants.Level", null)
                        .WithMany()
                        .HasForeignKey("LevelsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeePromotion", b =>
                {
                    b.HasOne("NorthStorm.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NorthStorm.Models.Promotion", null)
                        .WithMany()
                        .HasForeignKey("PromotionsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeSalary", b =>
                {
                    b.HasOne("NorthStorm.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NorthStorm.Models.Salary", null)
                        .WithMany()
                        .HasForeignKey("SalariesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("JobTitleLevel", b =>
                {
                    b.HasOne("NorthStorm.Models.JobTitle", null)
                        .WithMany()
                        .HasForeignKey("JobTitlesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NorthStorm.Models.Assistants.Level", null)
                        .WithMany()
                        .HasForeignKey("LevelsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("NorthStorm.Models.Assistants.Certificate", b =>
                {
                    b.HasOne("NorthStorm.Models.Assistants.GovernmentalInstitute", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("NorthStorm.Models.Assistants.GovernmentalInstitute", b =>
                {
                    b.HasOne("NorthStorm.Models.Assistants.GovernmentalInstituteClassification", "Classification")
                        .WithMany("GovernmentalInstitutes")
                        .HasForeignKey("ClassificationId");

                    b.HasOne("NorthStorm.Models.Assistants.Location", "Location")
                        .WithMany("GovernmentalInstitutes")
                        .HasForeignKey("LocationId");

                    b.HasOne("NorthStorm.Models.Assistants.GovernmentalInstitute", "ParentGovernmentalInstitute")
                        .WithMany("ChildGovernmentalInstitutes")
                        .HasForeignKey("ParentGovernmentalInstituteId");

                    b.Navigation("Classification");

                    b.Navigation("Location");

                    b.Navigation("ParentGovernmentalInstitute");
                });

            modelBuilder.Entity("NorthStorm.Models.Assistants.Level", b =>
                {
                    b.HasOne("NorthStorm.Models.Assistants.Location", "Location")
                        .WithMany("Levels")
                        .HasForeignKey("LocationId");

                    b.HasOne("NorthStorm.Models.Assistants.Level", "ParentLevel")
                        .WithMany("ChildLevels")
                        .HasForeignKey("ParentLevelId");

                    b.Navigation("Location");

                    b.Navigation("ParentLevel");
                });

            modelBuilder.Entity("NorthStorm.Models.Assistants.Location", b =>
                {
                    b.HasOne("NorthStorm.Models.Classifications.LocationClassification", null)
                        .WithMany("Locations")
                        .HasForeignKey("LocationClassificationId");

                    b.HasOne("NorthStorm.Models.Assistants.Location", "ParentLocation")
                        .WithMany("ChildLocations")
                        .HasForeignKey("ParentLocationId");

                    b.Navigation("ParentLocation");
                });

            modelBuilder.Entity("NorthStorm.Models.Employee", b =>
                {
                    b.HasOne("NorthStorm.Models.Classifications.Gender", "gender")
                        .WithMany("Employees")
                        .HasForeignKey("GenderId");

                    b.HasOne("NorthStorm.Models.Classifications.Nationality", "nationality")
                        .WithMany("Employees")
                        .HasForeignKey("NationalityId");

                    b.HasOne("NorthStorm.Models.Classifications.Race", "race")
                        .WithMany("Employees")
                        .HasForeignKey("RaceId");

                    b.HasOne("NorthStorm.Models.Recruitment", "Recruitment")
                        .WithMany("Employees")
                        .HasForeignKey("RecruitmentId");

                    b.HasOne("NorthStorm.Models.Classifications.Religion", "religion")
                        .WithMany("Employees")
                        .HasForeignKey("ReligionId");

                    b.HasOne("NorthStorm.Models.Assistants.Status", "status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Recruitment");

                    b.Navigation("gender");

                    b.Navigation("nationality");

                    b.Navigation("race");

                    b.Navigation("religion");

                    b.Navigation("status");
                });

            modelBuilder.Entity("NorthStorm.Models.EmployeeJobTitle", b =>
                {
                    b.HasOne("NorthStorm.Models.Employee", "Employee")
                        .WithMany("EmployeeJobTitles")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("NorthStorm.Models.JobTitle", "JobTitle")
                        .WithMany("EmployeeJobTitles")
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("JobTitle");
                });

            modelBuilder.Entity("NorthStorm.Models.JobTitle", b =>
                {
                    b.HasOne("NorthStorm.Models.Classifications.JobTitleClassification", "Classification")
                        .WithMany()
                        .HasForeignKey("ClassificationId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("NorthStorm.Models.Assistants.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("NorthStorm.Models.Classifications.JobTitleClassification", null)
                        .WithMany("JobTitles")
                        .HasForeignKey("JobTitleClassificationId");

                    b.HasOne("NorthStorm.Models.JobTitle", "ParentJobTitle")
                        .WithMany("ChildJobTitles")
                        .HasForeignKey("ParentJobTitleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Classification");

                    b.Navigation("Grade");

                    b.Navigation("ParentJobTitle");
                });

            modelBuilder.Entity("NorthStorm.Models.JobTransfer", b =>
                {
                    b.HasOne("NorthStorm.Models.Assistants.Level", "DestinationLevel")
                        .WithMany()
                        .HasForeignKey("DestinationLevelId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("NorthStorm.Models.Assistants.Level", null)
                        .WithMany("JobTransfers")
                        .HasForeignKey("LevelId");

                    b.Navigation("DestinationLevel");
                });

            modelBuilder.Entity("NorthStorm.Models.Assistants.GovernmentalInstitute", b =>
                {
                    b.Navigation("ChildGovernmentalInstitutes");
                });

            modelBuilder.Entity("NorthStorm.Models.Assistants.GovernmentalInstituteClassification", b =>
                {
                    b.Navigation("GovernmentalInstitutes");
                });

            modelBuilder.Entity("NorthStorm.Models.Assistants.Level", b =>
                {
                    b.Navigation("ChildLevels");

                    b.Navigation("JobTransfers");
                });

            modelBuilder.Entity("NorthStorm.Models.Assistants.Location", b =>
                {
                    b.Navigation("ChildLocations");

                    b.Navigation("GovernmentalInstitutes");

                    b.Navigation("Levels");
                });

            modelBuilder.Entity("NorthStorm.Models.Classifications.Gender", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("NorthStorm.Models.Classifications.JobTitleClassification", b =>
                {
                    b.Navigation("JobTitles");
                });

            modelBuilder.Entity("NorthStorm.Models.Classifications.LocationClassification", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("NorthStorm.Models.Classifications.Nationality", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("NorthStorm.Models.Classifications.Race", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("NorthStorm.Models.Classifications.Religion", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("NorthStorm.Models.Employee", b =>
                {
                    b.Navigation("EmployeeJobTitles");
                });

            modelBuilder.Entity("NorthStorm.Models.JobTitle", b =>
                {
                    b.Navigation("ChildJobTitles");

                    b.Navigation("EmployeeJobTitles");
                });

            modelBuilder.Entity("NorthStorm.Models.Recruitment", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
