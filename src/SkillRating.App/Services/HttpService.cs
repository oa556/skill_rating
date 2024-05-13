using System.Net.Http.Json;
using SkillRating.App.Models;

namespace SkillRating.App.Services;

public class HttpService
{
    private const string Url = "https://skill-rating.azurewebsites.net/";

    private readonly HttpClient _httpClient = new();

    public async Task<LeaderboardEntry[]> GetLeaderboardAsync()
    {
        var response = await _httpClient.GetAsync(Url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<LeaderboardEntry[]>() ?? [];
        }

        return [];
    }

    public async Task<Match[]> GetMatchesAsync()
    {
        var response = await _httpClient.GetAsync(Url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Match[]>() ?? [];
        }

        return [];
    }
}
