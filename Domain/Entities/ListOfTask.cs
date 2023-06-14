using Domain.Entities.Base;

namespace Domain.Entities
{
    public class ListOfTask : EntityBase
    {
        public string Name { get; set; }

        public DateTime CreationDate = DateTime.Now;

        public long CreatorId { get; set; }

        public ICollection<ListOfTasksToUsers> ListOfTasksToUsers { get; set; }
    }
}
