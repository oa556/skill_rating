using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SkillRating.App.Models;
using SkillRating.App.Services;
using System.Collections.ObjectModel;

namespace SkillRating.App.ViewModels;

public partial class LeaderboardViewModel(HttpService httpService) : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<LeaderboardEntry> items = [];

    [ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
    async Task GetAsync()
    {
        var leaderboard = await httpService.GetLeaderboardAsync();

        Items.Clear();

        foreach (var item in leaderboard) {
            Items.Add(item);
        }

        IsRefreshing = false;
    }
}
