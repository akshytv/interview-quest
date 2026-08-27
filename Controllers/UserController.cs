using InterviewQuest.API.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace InterviewQuest.API.Controllers;

[ApiController]
[Route("user")]
public class UserController(IMediator mediator): ControllerBase
{
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegistorUser([FromBody] string UserId)
    {
        var command = new RegisterUserCommand
        {
            UserId = UserId
        };
        bool response = await mediator.Send(command);
        return Ok(response);
    }
}