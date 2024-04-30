using System.Reflection;
using SkillRating.Api.HttpContext;
using SkillRating.LeaderboardModule;
using SkillRating.MatchesModule;
using SkillRating.PlayersModule;
using SkillRating.SharedKernel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

List<Assembly> mediatRAssemblies = [];
builder.Services.AddPlayersModule(builder.Configuration, mediatRAssemblies);
builder.Services.AddMatchesModule(builder.Configuration, mediatRAssemblies);
builder.Services.AddLeaderboardModule(builder.Configuration, mediatRAssemblies);
builder.Services.AddSharedKernel();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(mediatRAssemblies.ToArray()));

builder.Services.AddScoped<IHttpContext, MockHttpContext>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
