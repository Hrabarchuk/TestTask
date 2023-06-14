using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ListOfTasksToUsers
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public long ListOfTasksId { get; set; }
        public ListOfTask ListOfTasks { get; set; }
    }
}
