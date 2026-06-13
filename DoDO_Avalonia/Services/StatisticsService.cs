using DoDO.Avalonia.Data;
using DoDO_Avalonia.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoDO.Avalonia.Services;

public class StatisticsService
{
    public async Task<GameStatistics>
        CalculateAsync(List<GameResult> results)
    {
        var avgTask = Task.Run(
            () => results.Average(x => x.EnemiesKilled));

        var maxTask = Task.Run(
            () => results.Max(x => x.EnemiesKilled));

        var countTask = Task.Run(
            () => results.Count);

        await Task.WhenAll(
            avgTask,
            maxTask,
            countTask);

        return new GameStatistics
        {
            AverageKills = avgTask.Result,
            MaxKills = maxTask.Result,
            TotalGames = countTask.Result
        };
    }
}