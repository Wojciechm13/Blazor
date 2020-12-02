using System.Threading.Tasks;

namespace Assignment1.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
    }
}