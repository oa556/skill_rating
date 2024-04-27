namespace SkillRating.Api.Contracts.Common;

public class BaseResponse<TData> : BaseResponse
{
    public TData? Data { get; set; }
}
