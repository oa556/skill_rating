using SkillRating.SharedKernel;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.Api.Contracts.Common;

public class BaseResponse
{
    public bool Success { get; set; }

    public Error? Error { get; set; }
}
