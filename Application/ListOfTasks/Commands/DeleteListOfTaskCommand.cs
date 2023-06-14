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
    public class DeleteListOfTaskCommand : IRequest<long>
    {
        public long Id { get; set; }

        public class DeleteListOfTaskCommandHandler : IRequestHandler<DeleteListOfTaskCommand, long>
        {
            private readonly IListOfTasksRepository _listOfTasksRepository;
            private readonly IListOfTasksToUsersRepository _listOfTasksToUsersRepository;
            public DeleteListOfTaskCommandHandler(IListOfTasksRepository listOfTasksRepository, IListOfTasksToUsersRepository listOfTasksToUsersRepository)
            {
                _listOfTasksRepository = listOfTasksRepository;
                _listOfTasksToUsersRepository = listOfTasksToUsersRepository;
            }

            public async Task<long> Handle(DeleteListOfTaskCommand request, CancellationToken cancellationToken)
            {

                var deletedLOT = await _listOfTasksRepository.DeleteListOfTasksAsync(request.Id);
                await _listOfTasksToUsersRepository.DeleteListOfTasksToUsersAsync(deletedLOT);

                return deletedLOT;

            }
        }
    }
}
