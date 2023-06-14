using Application.Tasks.Commands;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ListOfTasks.Commands
{
    public class UpdateListOfTasksCommand : IRequest<long>
    {
        public string Name { get; set; }
        public List<long> AssignedUsers { get; set; }

        public class UpdateListOfTasksCommandHandler : IRequestHandler<UpdateListOfTasksCommand, long>
        {
            private readonly IListOfTasksRepository _listOfTasksRepository;
            private readonly IListOfTasksToUsersRepository _listOfTasksToUsersRepository;
            private readonly IUserRepository _userRepository;
            public UpdateListOfTasksCommandHandler(IListOfTasksRepository listOfTasksRepository, IListOfTasksToUsersRepository listOfTasksToUsersRepository, IUserRepository userRepository)
            {
                _listOfTasksRepository = listOfTasksRepository;
                _listOfTasksToUsersRepository = listOfTasksToUsersRepository;
                _userRepository = userRepository;
            }

            public async Task<long> Handle(UpdateListOfTasksCommand request, CancellationToken cancellationToken)
            {
                ListOfTask listOfTasks = new ListOfTask
                {
                    Name = request.Name,
                };

                var updatedLOT = await _listOfTasksRepository.UpdateListOfTasksAsync(listOfTasks);
                if (updatedLOT != null && request.AssignedUsers.Count > 0)
                {
                    foreach (var assignUser in request.AssignedUsers)
                    {
                        var existedUser = _userRepository.GetUserByIdAsync(assignUser) ?? null;
                        var assignedUser = await _listOfTasksToUsersRepository.GetListOfTasksToUsersAssignedToListAsync(updatedLOT, assignUser);
                        if (existedUser != null && assignedUser == null)
                        {
                            ListOfTasksToUsers list = new ListOfTasksToUsers
                            {
                                ListOfTasksId = updatedLOT,
                                UserId = assignUser,
                            };
                            await _listOfTasksToUsersRepository.UpdateListOfTasksToUsersAsync(list);
                        }
                    }
                }
                return updatedLOT;

            }
        }
    }
}
