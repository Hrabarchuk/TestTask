using Application.ListOfTasks.Queries.Vm;
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
    public class GetListOfListQuery : IRequest<ListOfListOfTasksVM>
    {
        public int StartIndex { get; set; }

        public int PageSize { get; set; }

        public class GetAvailableAuditoriumsQueryHandler : IRequestHandler<GetListOfListQuery, ListOfListOfTasksVM>
        {
            private readonly IListOfTasksRepository _listOfTasksRepository;

            public GetAvailableAuditoriumsQueryHandler(IListOfTasksRepository listOfTasksRepository)
            {
                _listOfTasksRepository = listOfTasksRepository;
            }

            public async Task<ListOfListOfTasksVM> Handle(GetListOfListQuery request, CancellationToken cancellationToken)
            {
                var res =  await _listOfTasksRepository.GetListsOfTasksAsync(request.StartIndex, request.PageSize);
                return new ListOfListOfTasksVM
                {
                    ListOfTasks = res,
                    StartIndex = request.StartIndex,
                    PageSize = request.PageSize
                };
            }
        }
    }
}
