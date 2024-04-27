using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillRating.Api.Contracts.Players;
using SkillRating.Api.HttpContext;
using SkillRating.PlayersModule.Application.GetOpponents;
using SkillRating.PlayersModule.Application.Register;
using SkillRating.PlayersModule.Application.UpdateImage;
using SkillRating.PlayersModule.Application.UpdateName;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.Api.Controllers;

[Route("players")]
public class PlayersController(
    ISender sender,
    IHttpContext httpContext)
    : ApiController
{
    [HttpGet("")]
    public async Task<IActionResult> GetOpponents()
    {
        var query = new GetOpponentsQuery(httpContext.PlayerId);

        Result<PlayerDto[]> result = await sender.Send(query);

        return GetResponse(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.Phone);
        
        Result result = await sender.Send(command);

        return GetResponse(result);
    }

    [HttpPut("name")]
    public async Task<IActionResult> UpdateName(UpdateNameRequest request)
    {
        var command = new UpdateNameCommand(httpContext.PlayerId, request.Name);

        Result result = await sender.Send(command);

        return GetResponse(result);
    }

    [HttpPut("image")]
    public async Task<IActionResult> UpdateImage(UpdateImageUrlRequest request)
    {
        var command = new UpdateImageCommand(httpContext.PlayerId, request.ImageUrl);

        Result result = await sender.Send(command);

        return GetResponse(result);
    }
}
