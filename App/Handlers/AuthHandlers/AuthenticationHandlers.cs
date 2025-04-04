using App.Query.AuthQuery;
using App.Response.AuthResponse;
using App.Utils;
using Infra.Repository.Interface;
using MediatR;

namespace App.Handlers.AuthHandlers
{
    public class AuthenticationHandlers : IRequestHandler<AuthenticationQuery, AuthenticationResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public AuthenticationHandlers(IUserRepository _userRepository, IAuthService _authService) 
        {
            this._userRepository = _userRepository;
            this._authService = _authService;
        }
        public async Task<AuthenticationResponse> Handle(AuthenticationQuery request, CancellationToken cancellationToken)
        {

            var user = await this._userRepository.GetByAsync(u => u.Email == request.Email);

            if (user == null)
            {

                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            if (PasswordHasherUtils.VerifyPassword(request.Password, user.Password))
            {
                return new AuthenticationResponse
                {
                    Token = this._authService.GenerateToken(user.Name, user.Email, user.Id)
                };

            }
            throw new KeyNotFoundException("Credencias invalidas.");
        }
    }
}
