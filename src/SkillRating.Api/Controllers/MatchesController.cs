using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillRating.Api.Contracts.Matches;
using SkillRating.Api.HttpContext;
using SkillRating.MatchesModule.Application.EnterOutcome;
using SkillRating.MatchesModule.Application.GetHistory;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.Api.Controllers;

[Route("matches")]
public class MatchesController(
    ISender sender,
    IHttpContext httpContext)
    : ApiController
{
    [HttpGet("")]
    public async Task<IActionResult> GetHistory()
    {
        var query = new GetHistoryQuery(httpContext.PlayerId);

        Result<MatchDto[]> result = await sender.Send(query);

        return GetResponse(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> EnterOutcome(EnterOutcomeRequest request)
    {
        var command = new EnterOutcomeCommand(
            httpContext.PlayerId,
            request.WinnerIds,
            request.LoserIds);

        Result result = await sender.Send(command);

        return GetResponse(result);
    }
}
