﻿using Microsoft.EntityFrameworkCore;
using MyProject.Repository.Entity;
using MyProject.Repository.Interfaces;

namespace DataContext
{
    public class Db : DbContext, IContext
    {
        public DbSet<Category> Categories { get ; set ; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<User> Users { get ; set ; }


        public async Task save()
        {
            await SaveChangesAsync();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=TAMI\\SQLEXPRESS;database=PodcastsDB;trusted_connection=true");
        }
    }
}