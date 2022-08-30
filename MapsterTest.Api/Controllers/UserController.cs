using MapsterTest.Api.Features.Users.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MapsterTest.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private IMediator? _mediatorInstance;
    protected IMediator? Mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await Mediator.Send(new GetAllUsersQuery()).ConfigureAwait(false));
    }
}