using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using API.DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Assignment1.Data
{
    public class DBSeeder
    {
        public static void Seed(IList<Person> persons)
        {
            // CleanInterestObjects(families);

            Console.WriteLine("Add persons..");
            AddPersons(persons);
            Console.WriteLine("Done!");
        }

        public static void SeedUsers(IList<User> users)
        {
            // CleanInterestObjects(families);

            Console.WriteLine("Add users..");
            AddUsers(users);
            Console.WriteLine("Done!");
        }


        private static void AddPersons(IList<Person> persons)
        {
            foreach (Person person in persons)
            {
                using (PersonDBContext fctxt = new PersonDBContext())
                {
                    Console.WriteLine(person.ToString());
                    fctxt.Persons.AddAsync(person);
                    fctxt.Entry(person).State = EntityState.Added;
                    //fctxt.Entry(adult).State = EntityState.Detached;
                    fctxt.SaveChangesAsync();
                }
            }
        }

        private static void AddUsers(IList<User> users)
        {
            foreach (User user in users)
            {
                using (PersonDBContext fctxt = new PersonDBContext())
                {
                    Console.WriteLine(user.ToString());
                    fctxt.Users.AddAsync(user);
                    fctxt.Entry(user).State = EntityState.Added;
                    //fctxt.Entry(user).State = EntityState.Detached;
                    fctxt.SaveChangesAsync();
                }
            }
        }



        public static IList<Person> ReadJsonFromFile(string path)
        {
            IList<Person> persons;
            using (var jsonReader = File.OpenText(path))
            {
                persons = JsonSerializer.Deserialize<List<Person>>(jsonReader.ReadToEnd());
            }

            return persons;
        }
    }
}