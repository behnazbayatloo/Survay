using Microsoft.EntityFrameworkCore;
using Survay.Domain.Entities;
using Survay.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Infrastructure.AppDb
{
    public class AppDbContext:DbContext
    {
        private readonly string _connectionstring = @"Server=DESKTOP-LO9POA3\SQLEXPRESS;Database=Survay;Integrated Security = true;Encrypt=True;TrustServerCertificate=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionstring);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());

            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new NormalUserConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new Poll_NUserConfiguration());
            modelBuilder.ApplyConfiguration(new PollConfiguration());
            modelBuilder.ApplyConfiguration(new VoteConfiguration());


        }

        public DbSet<Poll> Polls { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<NormalUser> NormalUsers { get; set; }
        public DbSet<Question> Questions { get; set; }  
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Poll_NUser> Poll_NUsers { get; set; }
    }
}
