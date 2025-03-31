using App.Response.UserResponse;
using MediatR;

namespace App.Query.UserQuery
{
    public record UserGetAllQuery :IRequest<List<UserGetAllResponse>>
    {
    }
}
