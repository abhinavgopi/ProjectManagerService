using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ProjectManager.Entities;

namespace ProjectManager.DAL
{

    public class ManagerContext : DbContext
    {
        public ManagerContext() : base("name=ManagerContext")
        {

        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasKey<int>(a => a.TaskId);
            modelBuilder.Entity<Task>().Property(a => a.TaskId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Task>().Property(a => a.TaskName).IsRequired();
            modelBuilder.Entity<Task>().Property(a => a.ParentTaskId).IsOptional();
            modelBuilder.Entity<Task>().Property(a => a.Priority).IsOptional();
            modelBuilder.Entity<Task>().Property(a => a.StartDate).IsOptional();
            modelBuilder.Entity<Task>().Property(a => a.EndDate).IsOptional();
            modelBuilder.Entity<Task>().Property(a => a.IsEnd).IsOptional();
            modelBuilder.Entity<Task>().Property(a => a.projectId).IsOptional();
            modelBuilder.Entity<Task>().Property(a => a.UserId).IsOptional();
            modelBuilder.Entity<Task>().Property(a => a.IsParent).IsOptional();


            modelBuilder.Entity<Project>().HasKey<int>(a => a.ProjectId);
            modelBuilder.Entity<Project>().Property(a => a.ProjectId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Project>().Property(a => a.Priority).IsOptional();
            modelBuilder.Entity<Project>().Property(a => a.StartDate).IsOptional();
            modelBuilder.Entity<Project>().Property(a => a.EndDate).IsOptional();
            modelBuilder.Entity<Project>().Property(a => a.UserId).IsOptional();


            modelBuilder.Entity<User>().HasKey<int>(a => a.UserId);
            modelBuilder.Entity<User>().Property(a => a.UserId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}

