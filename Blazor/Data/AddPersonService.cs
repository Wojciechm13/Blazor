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
        private string uri = "http://localhost:5000";
        private readonly HttpClient client;

        public AddPersonService()
        {
            client = new HttpClient();
        }
            
        
            
        public async Task<List<Person>> GetPersonsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri+"/Persons");
            string message = await stringAsync;
            List<Person> result = JsonSerializer.Deserialize<List<Person>>(message);
            return result;
        }

        public async Task AddPersonAsync(Person person)
        {
            string todoAsJson = JsonSerializer.Serialize(person);
            HttpContent content = new StringContent(todoAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri+"/Persons", content);
        }

        public async Task RemovePersonAsync(int personId)
        {
            await client.DeleteAsync($"{uri}/Persons/{personId}");
        }

        public async Task UpdatePersonAsync(Person person) {
            string todoAsJson = JsonSerializer.Serialize(person);
            HttpContent content = new StringContent(todoAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PatchAsync($"{uri}/Persons/{person.Id}", content);
        }
    }
}