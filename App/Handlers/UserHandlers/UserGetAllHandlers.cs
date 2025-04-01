

using App.Query.UserQuery;
using App.Response.UserResponse;
using Infra.Repository.Interface;
using MediatR;

namespace App.Handlers.UserHandlers
{
    public class UserGetAllHandlers : IRequestHandler<UserGetAllQuery, List<UserGetAllResponse>>
    {
        private readonly IUserRepository _userRepository;
        public UserGetAllHandlers(IUserRepository _userRepository) {
            
            this._userRepository = _userRepository;
        }

        public async Task<List<UserGetAllResponse>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            var users =  await _userRepository.GetAllAsync();
            var result =  users.Select(user => new UserGetAllResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            }).ToList();

            return result;
        }
    }
}
