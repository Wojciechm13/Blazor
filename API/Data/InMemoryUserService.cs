using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using API.DataAccess;
using Microsoft.EntityFrameworkCore;


namespace Assignment1.Data
{
    public class InMemoryUserService :IUserService
    {
        private PersonDBContext ctx;

        public InMemoryUserService(PersonDBContext ctx)
        {
            this.ctx = ctx;
        }
        
        

        public async Task<User> ValidateUser(string userName, string password)
        {
            User user = ctx.Users.FirstOrDefault(u => u.UserName.Equals(userName) && u.Password.Equals(password));
            if (user != null)
            {
                return user;
            } 
            throw new Exception("User not found");
        }

        public async Task<IList<User>> allUsersAsync()
        {
            return await ctx.Users.ToListAsync();
        }
    }
}