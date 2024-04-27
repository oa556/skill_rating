using SkillRating.Api;
using SkillRating.Api.HttpContext;
using SkillRating.PlayersModule;
using SkillRating.SharedKernel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddPlayersModule(builder.Configuration);
builder.Services.AddSharedKernel();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies([typeof(IPlayersModule).Assembly]));

builder.Services.AddScoped<IHttpContext, MockHttpContext>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
