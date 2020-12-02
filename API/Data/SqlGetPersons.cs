using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;

namespace Assignment1.Data
{
    public class SqlGetPersons : IAddPersonService
    {

        private PersonDBContext ctx;

        public SqlGetPersons(PersonDBContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<List<Person>> GetPersonsAsync()
        {
            return await ctx.Persons.ToListAsync();
        }

        public async Task AddPersonAsync(Person person)
        {
            EntityEntry<Person> newlyAdded = await ctx.Persons.AddAsync(person);
            await ctx.SaveChangesAsync();
        }

        public async Task RemovePersonAsync(int personId)
        {
            Person toDelete = await ctx.Persons.FirstOrDefaultAsync(t => t.Id == personId);
            if (toDelete != null)
            {
                ctx.Persons.Remove(toDelete);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task UpdatePersonAsync(Person person)
        {
            try
            {
                Person toUpdate = await ctx.Persons.FirstAsync(t => t.Id == person.Id);
                ctx.Update(toUpdate);
                await ctx.SaveChangesAsync();
                //return toUpdate;
            }
            catch (Exception e)
            {
                throw new Exception($"Did not find todo with id{person.Id}");
            }
        }
    }
}