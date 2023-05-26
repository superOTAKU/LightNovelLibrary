using LightNovelLibrary.Modules.User.Application.Commands.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LightNovelLibrary.API.UserControllers;
[Route("[controller]")]
[ApiController]
public class UserRegisterController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserRegisterController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async void Register([FromBody]RegisterUserCommand command)
    {
        await _mediator.Send(command);
    }

}
