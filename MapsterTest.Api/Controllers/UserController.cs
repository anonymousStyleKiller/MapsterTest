using MapsterTest.Api.Features.Users.Queries.GetAllByAutoMapper;
using MapsterTest.Api.Features.Users.Queries.GetAllByDapper;
using MapsterTest.Api.Features.Users.Queries.GetAllByMapster;
using MapsterTest.Api.Features.Users.Queries.GetByDapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MapsterTest.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private IMediator? _mediatorInstance;
    protected IMediator? Mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
    
    [HttpGet("/byAutoMapper")]
    public async Task<IActionResult> GetAllUsersByAutoMapper()
    {
        return Ok(await Mediator.Send(new GetAllUsersByAutoMapperQuery()).ConfigureAwait(false));
    }
    
    [HttpGet("/byMapster")]
    public async Task<IActionResult> GetAllUsersByMapster()
    {
        return Ok(await Mediator.Send(new GetAllUsersBMapsterQuery()).ConfigureAwait(false));
    }

        
    [HttpGet("/dapper/{id}")]
    public async Task<IActionResult> GetUsersByDapper(string id)
    {
        return Ok(await Mediator.Send(new GetByDapperQuery(id)).ConfigureAwait(false));
    }
    
    [HttpGet("/byAutoMapperWithDapper")]
    public async Task<IActionResult> GetAllUsersByDapper()
    {
        return Ok(await Mediator.Send(new GetAllByDapperQuery()).ConfigureAwait(false));
    }
}