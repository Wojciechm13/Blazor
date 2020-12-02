using Assignment1.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace API.DataAccess
{
    public class PersonDBContext : DbContext
    {
        public DbSet<Person> Persons { set; get; }
        public DbSet<User> Users { set; get; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // name of database
            optionsBuilder.UseSqlite(@"Data Source = /Users/wojtek/RiderProjects/Blazor/Database/persons.db");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasKey(fam => new {fam.Id});
            modelBuilder.Entity<User>().HasKey(us => new {us.UserName});
        }
    }
}