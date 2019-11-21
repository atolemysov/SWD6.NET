using System;
using courseProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace courseProject.Data
{
    //Changed default DbContext to IdentityDbContext
    public class MyContext : IdentityDbContext<User>
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        //public new DbSet<Role> Roles { get; set; }
        public new DbSet<User> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Therapy> Therapies { get; set; }
        public DbSet<Video> Videos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //One to many between Survey and Therapy -––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––
            builder.Entity<Survey>()
                .HasOne(p => p.Survey_Therapy)
                .WithMany(b => b.Surveys);
            //One to many between Survey and Therapy END-––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––

            //One to many between Video and Therapy -––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––
            builder.Entity<Video>()
                .HasOne(p => p.Video_Therapy)
                .WithMany(b => b.Videos);
            //One to many between Video and Therapy END-––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––

            //Many to many User_Answers between User and Survey -––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––
            builder.Entity<User_Answers>()
           .HasKey(pt => new { pt.UserId, pt.SurveyId });

            builder.Entity<User_Answers>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.User_Answers)
                .HasForeignKey(pt => pt.UserId);

            builder.Entity<User_Answers>()
                .HasOne(pt => pt.Survey)
                .WithMany(t => t.User_Answers);
                
            //Many to many User_Answers between User and Survey END -––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––


            //Many to many User_Therapy between User and Therapy -––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––
            builder.Entity<User_Therapy>()
           .HasKey(pt => new { pt.UserId, pt.TherapyId });

            builder.Entity<User_Therapy>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.User_Therapies)
                .HasForeignKey(pt => pt.UserId);

            builder.Entity<User_Therapy>()
                .HasOne(pt => pt.Therapy)
                .WithMany(t => t.User_Therapies)
                .HasForeignKey(pt => pt.TherapyId);
            //Many to many User_Therapy between User and Therapy END -––––––––––––––-––––––––––––––-––––––––––––––-––––––––––––––

            

            
        }

        internal bool Find(string login)
        {
            throw new NotImplementedException();
        }

        internal bool Find(User user)
        {
            throw new NotImplementedException();
        }

        public DbSet<courseProject.Models.User_Answers> User_Answers { get; set; }


        public DbSet<courseProject.Models.User_Therapy> User_Therapy { get; set; }
    }
}
