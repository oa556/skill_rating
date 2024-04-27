using Microsoft.AspNetCore.Mvc;
using SkillRating.Api.Contracts.Common;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.Api.Controllers;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected IActionResult GetResponse(Result result)
    {
        return result.IsFailure ? GetBadRequest(result.Error) : GetOk();
    }

    protected IActionResult GetResponse<T>(Result<T> result)
    {
        return result.IsFailure ? GetBadRequest<T>(result.Error) : GetOk(result.Value);
    }

    private IActionResult GetBadRequest(Error error)
    {
        return BadRequest(new BaseResponse
        {
            Success = false,
            Error = error
        });
    }

    private IActionResult GetBadRequest<T>(Error error)
    {
        return BadRequest(new BaseResponse<T>
        {
            Success = false,
            Error = error
        });
    }

    private IActionResult GetOk()
    {
        return Ok(new BaseResponse
        {
            Success = true
        });
    }

    private IActionResult GetOk<T>(T data)
    {
        return Ok(new BaseResponse<T>
        {
            Success = true,
            Data = data
        });
    }
}
