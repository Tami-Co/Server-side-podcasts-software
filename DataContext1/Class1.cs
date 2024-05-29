
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using MyProject.Repository.Entity;
using MyProject.Repository.Interfaces;

namespace DataContext11
{
    public class Db : DbContext, IContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<User> Users { get; set; }


        public async Task save()
        {
            await SaveChangesAsync();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=TAMI\\SQLEXPRESS;database=PodcastsDB1;trusted_connection=true");
        }
    }
}