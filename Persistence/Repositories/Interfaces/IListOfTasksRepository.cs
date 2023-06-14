using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Interfaces
{
    public interface IListOfTasksRepository
    {
        public Task<List<ListOfTask>> GetListsOfTasksAsync(int StartIndex, int PageSize);
        public Task<ListOfTask> GetListOfTasksByIdAsync(long Id);
        public Task<ListOfTask> AddListOfTasksAsync(ListOfTask listOfTasks);
        public Task<long> UpdateListOfTasksAsync(ListOfTask listOfTasks);
        public Task<long> DeleteListOfTasksAsync(long Id);
    }
}
