

using App.Response.UserResponse;
using MediatR;

namespace App.Command.UserCommand
{
    public record UserUpdateCommand : IRequest<UserUpdateResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
    }
}
