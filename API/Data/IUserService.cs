using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment1.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
        Task<IList<User>> allUsersAsync();
    }
}