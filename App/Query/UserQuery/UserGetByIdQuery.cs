using App.Response.UserResponse;
using MediatR;

namespace App.Query.UserQuery
{
    public record UserGetByIdQuery: IRequest<UserGetByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
