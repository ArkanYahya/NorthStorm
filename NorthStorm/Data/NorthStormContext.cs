using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthStorm.Models;

namespace NorthStorm.Data
{
    public class NorthStormContext : DbContext
    {
        public NorthStormContext(DbContextOptions<NorthStormContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Recruitment> Recruitments { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Religion> Religiones { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<JobTransfer> JobTransfers { get; set; }


       //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>().ToTable("Employee");
        //    //modelBuilder.Entity<EmployeeRecruitment>().ToTable("EmployeeRecruitment");
        //    modelBuilder.Entity<Gender>().ToTable("Gender");
        //    modelBuilder.Entity<Nationality>().ToTable("Nationality");
        //    modelBuilder.Entity<Race>().ToTable("Race");
        //    modelBuilder.Entity<Recruitment>().ToTable("Recruitment");
        //    modelBuilder.Entity<Religion>().ToTable("Religion");
        //    modelBuilder.Entity<State>().ToTable("State");
        //    modelBuilder.Entity<Status>().ToTable("Status");


        //    يستخدم لتعيين مفتاح أساسي يتكون من  حقلين
        //     modelBuilder.Entity<EmployeeRecruitment>()
        //        .HasKey(c => new { c.RecruitmentId, c.EmployeeId });

        //    modelBuilder.Entity<Employee>()
        //        .Property(b => b.LastUpdated)
        //        .HasDefaultValueSql("getdate()")
        //        .ValueGeneratedOnUpdate();
        //}
    }
}
