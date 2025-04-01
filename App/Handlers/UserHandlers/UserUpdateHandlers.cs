using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Command.UserCommand;
using App.Response.UserResponse;
using Infra.Repository.Interface;
using MediatR;

namespace App.Handlers.UserHandlers
{
    class UserUpdateHandlers : IRequestHandler<UserUpdateCommand, UserUpdateResponse>
    {
        private IUserRepository _userRepository;

        public UserUpdateHandlers(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserUpdateResponse> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {

            var user = await this._userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            user.Name = request.Name;
            user.Email = request.Email;
            user.Description = request.Description;
            user.Password = request.Password;

            await this._userRepository.UpdateAsync(user);

            return new UserUpdateResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Description = user.Description

            };
        }
    }
}
