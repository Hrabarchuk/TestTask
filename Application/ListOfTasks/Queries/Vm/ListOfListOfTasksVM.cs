using Domain.Entities;

namespace Application.ListOfTasks.Queries.Vm
{
    public class ListOfListOfTasksVM
    {
        public List<ListOfTask> ListOfTasks { get; set; }

        public int StartIndex { get; set; }
        public int PageSize { get; set; }
    }
}
