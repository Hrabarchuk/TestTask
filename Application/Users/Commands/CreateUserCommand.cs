using Application.Tasks.Commands;
using Domain.Entities;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Users.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long ListOfTasksId { get; set; }


        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
        {
            private readonly IUserRepository _userRepository;
            public CreateUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                User user = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName
                };

                return await _userRepository.AddUserAsync(user);
            }
        }
    }
}
