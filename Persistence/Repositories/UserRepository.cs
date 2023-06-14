using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            var result = _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<long> DeleteUserAsync(long Id)
        {
            var filteredData = _dbContext.Users.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Users.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(long Id) => await _dbContext.Users.Where(x => x.Id == Id).FirstOrDefaultAsync();

        public async Task<List<User>> GetUserListAsync() => await _dbContext.Users.ToListAsync();

        public async Task<long> UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
