using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : ICrudRepository<User>
    {
        private readonly FrazzesPlatslageriDB _database;

        public UserRepository(FrazzesPlatslageriDB database)
        {
            _database = database;
        }

        public async Task<User> AddAsync(User user)
        {
            await _database.Users.AddAsync(user);
            await _database.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(Guid id)
        {
            // Fungerar som en if-sats, fast med mindre rader kod. Ifall id är null kastas ett exception.
            var user = await _database.Users.FindAsync(id) ?? throw new KeyNotFoundException($"User with ID {id} was not found.");

            _database.Users.Remove(user);
            await _database.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> Find(Expression<Func<User, bool>> expression)
        {
            return await _database.Users.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _database.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            // Fungerar som en if-sats, fast med mindre rader kod. Ifall id är null kastas ett exception.
            return await _database.Users.FindAsync(id) ?? throw new KeyNotFoundException("User not found.");
        }

        public async Task<User> UpdateAsync(User user)
        {
            _database.Update(user);
            await _database.SaveChangesAsync();
            return user;
        }
    }
}
