using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Interfaces
{
    public interface IListOfTasksToUsersRepository
    {
        public Task<List<ListOfTasksToUsers>> GetListOfTasksToUsersAsync();
        public Task<List<ListOfTasksToUsers>> GetListOfTasksToUsersByUserIdAsync(long userId);
        public Task<List<ListOfTasksToUsers>> GetListOfTasksToUsersByListIdAsync(long taskId);
        public Task<ListOfTasksToUsers> GetListOfTasksToUsersAssignedToListAsync(long taskId, long userId);
        public Task<ListOfTasksToUsers> AddListOfTasksToUsersAsync(ListOfTasksToUsers listOfTasksToUsers);
        public Task<long> UpdateListOfTasksToUsersAsync(ListOfTasksToUsers listOfTasksToUsers);
        public Task<long> DeleteListOfTasksToUsersAsync(long Id);
    }
}
