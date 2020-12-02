using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public class AddPersonService : IAddPersonService
    {
        private string peopleFile = "adults.json";
        private IList<Person> persons;

        public AddPersonService()
        {
            if (!File.Exists(peopleFile))
            {
                //Seed();
                WritePeopleToFile();
            }
            else
            {
                string content = File.ReadAllText(peopleFile);
                persons = JsonSerializer.Deserialize<List<Person>>(content);
            }
        }
            
            
            
        public async Task<IList<Person>> GetPersonsAsync()
        {
            List<Person> tmp = new List<Person>(persons);
            return tmp;
        }

        public async Task AddPersonAsync(Person person)
        {
            int max = persons.Max(person => person.Id);
            person.Id = (++max);
            persons.Add(person);
            WritePeopleToFile();
        }

        public async Task RemovePersonAsync(int personId)
        {
            Person toRemove = persons.First(t => t.Id == personId);
            persons.Remove(toRemove);
            WritePeopleToFile();
        }

        public async Task UpdatePersonAsync(Person person)
        {
            await RemovePersonAsync(person.Id);
            await AddPersonAsync(person);
            WritePeopleToFile();
        }
        
        
        private void WritePeopleToFile()
        {
            string productAsJson = JsonSerializer.Serialize(persons);
            File.WriteAllText(peopleFile, productAsJson);
        }
    }
}