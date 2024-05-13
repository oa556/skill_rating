using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SkillRating.App.Services;
using SkillRating.App.ViewModels;

namespace SkillRating.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<LeaderboardPage>();
            builder.Services.AddSingleton<LeaderboardViewModel>();

            builder.Services.AddSingleton<MatchesPage>();
            builder.Services.AddSingleton<MatchesViewModel>();

            builder.Services.AddSingleton<HttpService>();

            return builder.Build();
        }
    }
}
