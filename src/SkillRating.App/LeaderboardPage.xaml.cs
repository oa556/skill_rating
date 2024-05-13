using SkillRating.App.ViewModels;

namespace SkillRating.App;

public partial class LeaderboardPage : ContentPage
{
    public LeaderboardPage(LeaderboardViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
