using SkillRating.App.ViewModels;

namespace SkillRating.App;

public partial class MatchesPage : ContentPage
{
    public MatchesPage(MatchesViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
