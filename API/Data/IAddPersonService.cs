using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public interface IAddPersonService
    {
        Task<List<Person>> GetPersonsAsync();
        Task AddPersonAsync(Person person);
        Task RemovePersonAsync(int personId);
        Task UpdatePersonAsync(Person person);
    }
}