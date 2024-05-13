using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SkillRating.App.Models;
using SkillRating.App.Services;
using System.Collections.ObjectModel;

namespace SkillRating.App.ViewModels;

public partial class MatchesViewModel(HttpService httpService) : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<Match> items = [];

    [ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
    async Task GetAsync()
    {
        var matches = await httpService.GetMatchesAsync();

        Items.Clear();

        foreach (var item in matches) {
            Items.Add(item);
        }

        IsRefreshing = false;
    }
}
