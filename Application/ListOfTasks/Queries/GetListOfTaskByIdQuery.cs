using Domain.Entities;
using MediatR;
using Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ListOfTasks.Queries
{
    public class GetListOfTaskByIdQuery : IRequest<ListOfTask>
    {
        public long ListOfTaskId { get; set; }

        public class GetAvailableAuditoriumsQueryHandler : IRequestHandler<GetListOfTaskByIdQuery, ListOfTask>
        {
            private readonly IListOfTasksRepository _listOfTasksRepository;

            public GetAvailableAuditoriumsQueryHandler(IListOfTasksRepository listOfTasksRepository)
            {
                _listOfTasksRepository = listOfTasksRepository;
            }

            public async Task<ListOfTask> Handle(GetListOfTaskByIdQuery request, CancellationToken cancellationToken)
            {
                return await _listOfTasksRepository.GetListOfTasksByIdAsync(request.ListOfTaskId);
            }
        }

    }
}
