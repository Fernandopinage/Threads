using App.Query.UserQuery;
using App.Response.UserResponse;
using Infra.Repository.Interface;
using MediatR;

namespace App.Handlers.UserHandlers
{
    public class UserGetByIdHandlers : IRequestHandler<UserGetByIdQuery, UserGetByIdResponse>
    {
        private readonly IUserRepository _userRepository;

        public UserGetByIdHandlers(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async  Task<UserGetByIdResponse> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetByIdAsync(request.Id);

            return new UserGetByIdResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Description = user.Description,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };

        }
    }
}
