using Microsoft.EntityFrameworkCore;
using MyProject.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Interfaces
{
    public interface IContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lecture> Lectures { get; set;}
        public DbSet<Lecturer> Lecturers { get; set;}   
        public DbSet<Response> Responses { get; set; }
        public DbSet<User> Users { get; set; }

        public Task save();
    }
}
