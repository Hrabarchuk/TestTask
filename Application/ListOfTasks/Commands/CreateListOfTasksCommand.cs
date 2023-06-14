using Domain.Entities;
using MediatR;
using Persistence.Repositories;
using Persistence.Repositories.Interfaces;

namespace Application.Tasks.Commands
{
    public class CreateListOfTasksCommand : IRequest<ListOfTask>
    {
        public string Name { get; set; }
        public long UserId { get; set; }
        public List<long> AssignedUsers { get; set; }


        public class CreateListOfTasksCommandHandler : IRequestHandler<CreateListOfTasksCommand, ListOfTask>
        {
            private readonly IListOfTasksRepository _listOfTasksRepository;
            private readonly IListOfTasksToUsersRepository  _listOfTasksToUsersRepository;
            private readonly IUserRepository  _userRepository;
            public CreateListOfTasksCommandHandler(IListOfTasksRepository listOfTasksRepository, IListOfTasksToUsersRepository listOfTasksToUsersRepository, IUserRepository userRepository)
            {
                _listOfTasksRepository = listOfTasksRepository;
                _listOfTasksToUsersRepository = listOfTasksToUsersRepository;
                _userRepository = userRepository;
            }

            public async Task<ListOfTask> Handle(CreateListOfTasksCommand request, CancellationToken cancellationToken)
            {
                ListOfTask listOfTasks = new ListOfTask
                {
                   Name = request.Name,
                   CreatorId = request.UserId
                };

                var createdLOT =  await _listOfTasksRepository.AddListOfTasksAsync(listOfTasks);

                if(createdLOT != null && request.AssignedUsers.Count > 0)
                {
                    foreach (var assignedUser in request.AssignedUsers)
                    {
                        var existedUser = _userRepository.GetUserByIdAsync(assignedUser) ?? null;
                        if (existedUser != null) 
                        {
                            ListOfTasksToUsers list = new ListOfTasksToUsers
                            {
                                ListOfTasksId = createdLOT.Id,
                                UserId = assignedUser,
                            };
                            await _listOfTasksToUsersRepository.AddListOfTasksToUsersAsync(list);
                        } 
                    }
                }
                return createdLOT;
                
            }
        }
    }
}
