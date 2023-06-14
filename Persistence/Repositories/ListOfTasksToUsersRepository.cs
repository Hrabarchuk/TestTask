using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ListOfTasksToUsersRepository : IListOfTasksToUsersRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public ListOfTasksToUsersRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ListOfTasksToUsers> AddListOfTasksToUsersAsync(ListOfTasksToUsers listOfTasksToUsers)
        {
            var result = await _dbContext.ListOfTasksToUsers.AddAsync(listOfTasksToUsers);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<long> DeleteListOfTasksToUsersAsync(long Id)
        {
            var res = await _dbContext.ListOfTasksToUsers.Where(x => x.ListOfTasksId ==  Id).ToListAsync();
            _dbContext.ListOfTasksToUsers.RemoveRange(res);
            return Id;
        }

        public async Task<List<ListOfTasksToUsers>> GetListOfTasksToUsersByUserIdAsync(long userId)
        {
            return await _dbContext.ListOfTasksToUsers.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<List<ListOfTasksToUsers>> GetListOfTasksToUsersByListIdAsync(long taskId)
        {
            return await _dbContext.ListOfTasksToUsers.Where(x => x.ListOfTasksId == taskId).ToListAsync();
        }

        public Task<long> UpdateListOfTasksToUsersAsync(ListOfTasksToUsers listOfTasksToUsers)
        {
            throw new NotImplementedException();
        }

        public Task<List<ListOfTasksToUsers>> GetListOfTasksToUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ListOfTasksToUsers> GetListOfTasksToUsersAssignedToListAsync(long taskId, long userId)
        {
            return await _dbContext.ListOfTasksToUsers.Where(x => x.ListOfTasksId == taskId && x.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
