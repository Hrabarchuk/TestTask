using Domain.Entities.Base;

namespace Domain.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<ListOfTasksToUsers> ListOfTasksToUsers { get; set; }

    }
}
