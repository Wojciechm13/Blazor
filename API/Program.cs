using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.DataAccess;
using Assignment1.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Models;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (PersonDBContext personDbContext= new PersonDBContext())
            {
                //adultContext.RemoveRange(adultContext.Adults);
                //adultContext.SaveChanges();   
                if (!personDbContext.Persons.Any())
                {
                    Seed();
                }
            }
            using (PersonDBContext userContext = new PersonDBContext())
            {
                //adultContext.RemoveRange(adultContext.Adults);
                //adultContext.SaveChanges();   
                if (!userContext.Users.Any())
                {
                    SeedUsers();
                }
            }
            CreateHostBuilder(args).Build().Run();
        }
        
        private static void Seed()
        {
            IList<Person> persons = DBSeeder.ReadJsonFromFile("adults.json");
            string famSerialized = JsonSerializer.Serialize(persons, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            DBSeeder.Seed(persons);
        }
        
        
        private static void SeedUsers()
        {
            IList<User> users = new[] {
                new User {
                    UserName = "wojtek",
                    Password = "123456",
                    Securitylevel = 4
                },
                new User {
                    UserName = "pawel",
                    Password = "123456",
                    Securitylevel = 3
                },
                new User {
                    UserName = "dumitrus",
                    Password = "123456",
                    Securitylevel = 2
                }
            }.ToList();
            
            DBSeeder.SeedUsers(users);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}