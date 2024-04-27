namespace SkillRating.Api.HttpContext;

internal sealed class MockHttpContext : IHttpContext
{
    public Guid PlayerId => new("72B0BC4D-78E2-4D02-AE6D-539F7F06D4CE");
}
