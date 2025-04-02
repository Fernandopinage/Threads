
using App.Response.AuthResponse;
using MediatR;

namespace App.Query.AuthQuery
{
    public record AuthenticationQuery :IRequest<AuthenticationResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
