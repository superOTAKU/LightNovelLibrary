using LightNovelLibrary.Modules.User.Application.Commands.UserLogin;
using LightNovelLibrary.Modules.User.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LightNovelLibrary.API.UserControllers;

[Route("[controller]")]
[ApiController]
public class UserLoginController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserLoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<AuthenticationTokenDto> Login([FromBody]UserLoginCommand command)
    {
        return await _mediator.Send(command);
    }

}
