using System;
using courseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace courseProject.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Therapy> Therapies { get; set; }
        public DbSet<Video> Videos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to many between User and Role -––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––
            modelBuilder.Entity<User>()
                .HasOne(p => p.User_Role)
                .WithMany(b => b.Users);
            //One to many between User and Role END -––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––

            //One to many between Survey and Therapy -––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––
            modelBuilder.Entity<Survey>()
                .HasOne(p => p.Survey_Therapy)
                .WithMany(b => b.Surveys);
            //One to many between Survey and Therapy END-––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––

            //One to many between Video and Therapy -––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––
            modelBuilder.Entity<Video>()
                .HasOne(p => p.Video_Therapy)
                .WithMany(b => b.Videos);
            //One to many between Video and Therapy END-––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––

            //Many to many User_Answers between User and Survey -––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––
            modelBuilder.Entity<User_Answers>()
           .HasKey(pt => new { pt.UserId, pt.SurveyId });

            modelBuilder.Entity<User_Answers>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.User_Answers)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<User_Answers>()
                .HasOne(pt => pt.Survey)
                .WithMany(t => t.User_Answers)
                .HasForeignKey(pt => pt.SurveyId);
            //Many to many User_Answers between User and Survey END -––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––


            //Many to many User_Therapy between User and Therapy -––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––
            modelBuilder.Entity<User_Therapy>()
           .HasKey(pt => new { pt.UserId, pt.TherapyId });

            modelBuilder.Entity<User_Therapy>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.User_Therapies)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<User_Therapy>()
                .HasOne(pt => pt.Therapy)
                .WithMany(t => t.User_Therapies)
                .HasForeignKey(pt => pt.TherapyId);
            //Many to many User_Therapy between User and Therapy END -––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––

        }


        public DbSet<courseProject.Models.User_Answers> User_Answers { get; set; }


        public DbSet<courseProject.Models.User_Therapy> User_Therapy { get; set; }
    }
}
