using App.Command.UserCommand;
using App.Query.UserQuery;
using App.Response.UserResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<UserCreateResponse>> create(UserCreateCommand command)
        { 
            return Ok(await _mediator.Send(command));
           
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<List<UserGetAllResponse>>> GetAll()
        {
            var query = new UserGetAllQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGetByIdResponse>> GetById(Guid id)
        {
            var query = new UserGetByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


    }
}
