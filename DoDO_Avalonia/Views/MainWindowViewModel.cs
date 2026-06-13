using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DoDO.Avalonia.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DoDO.Avalonia.ViewModels;

public partial class MainWindowViewModel
    : ObservableObject
{
    [ObservableProperty]
    private string gameLog = "";

    public ObservableCollection<GameResult>
        Results { get; } = new();

    [RelayCommand]
    public async Task SaveTestResult()
    {
        using var db = new GameDbContext();

        db.Results.Add(
            new GameResult
            {
                HeroClass = "Warrior",
                EnemiesKilled = Random.Shared.Next(1,20),
                PlayedAt = DateTime.Now
            });

        await db.SaveChangesAsync();

        await LoadResults();
    }

    [RelayCommand]
    public async Task LoadResults()
    {
        using var db = new GameDbContext();

        var results =
            await db.Results
                .OrderByDescending(x => x.PlayedAt)
                .ToListAsync();

        Results.Clear();

        foreach (var item in results)
        {
            Results.Add(item);
        }
    }
}