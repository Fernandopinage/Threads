using App.Command.UserCommand;
using App.Response.UserResponse;
using App.Utils;
using Domain.Entity;
using Infra.Repository.Interface;
using MediatR;

namespace App.Handlers.UserHandlers
{
    public class UserCreateHandlers : IRequestHandler<UserCreateCommand, UserCreateResponse>
    {
        private readonly IUserRepository _userRepository;
        public UserCreateHandlers(IUserRepository _userRepository) {
            this._userRepository = _userRepository;
        }
        public async Task<UserCreateResponse> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = PasswordHasherUtils.HashPassword(request.Password),
                Description = request.Description
            };

            await _userRepository.AddAsync(user);

            return new UserCreateResponse
            {
                Id = user.Id
            };

        }
    }
}
