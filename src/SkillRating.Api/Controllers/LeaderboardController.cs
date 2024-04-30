using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkillRating.Api.Contracts.Leaderboard;
using SkillRating.LeaderboardModule.Application.GetAll;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.Api.Controllers;

[Route("leaderboard")]
public class LeaderboardController(ISender sender) : ApiController
{
    [HttpGet("")]
    public async Task<IActionResult> GetLeaderboard()
    {
        var query = new GetLeaderboardQuery();

        Result<LeaderboardEntryDto[]> result = await sender.Send(query);

        return GetResponse(result);
    }
}
