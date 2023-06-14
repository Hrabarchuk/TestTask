using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories
{
    public class ListOfTasksRepository : IListOfTasksRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ListOfTasksRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ListOfTask> AddListOfTasksAsync(ListOfTask listOfTasks)
        {
            var result = _dbContext.ListsOfTasks.Add(listOfTasks);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<long> DeleteListOfTasksAsync(long Id)
        {
            var filteredData = _dbContext.ListsOfTasks.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.ListsOfTasks.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<ListOfTask> GetListOfTasksByIdAsync(long Id)
        {
           return await _dbContext.ListsOfTasks.Where(x => x.Id == Id).Include(x => x.ListOfTasksToUsers).FirstOrDefaultAsync();
        }

        public  async Task<List<ListOfTask>> GetListsOfTasksAsync(int StartIndex, int PageSize)
        {
            return await _dbContext.ListsOfTasks.Skip(StartIndex).Take(PageSize).OrderByDescending(x => x.CreationDate).ToListAsync();
        }

        public async Task<long> UpdateListOfTasksAsync(ListOfTask listOfTasks)
        {
            _dbContext.ListsOfTasks.Update(listOfTasks);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
