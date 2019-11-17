using Asp.Net_Core_project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Core_project
{
    public class UniversityContext : DbContext
    {
        private readonly IOptions<RepositoryOptions> options;

        public UniversityContext(IOptions<RepositoryOptions> options)
        { 
            this.options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(options.Value.DefaultConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<HomeTask> HomeTasks { get; set; }

        public DbSet<Lecturer> Lecturers { get; set; }
    }
}
