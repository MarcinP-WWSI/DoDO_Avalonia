using System;
using System.Collections.Generic;
using System.Text;

namespace DoDO.Avalonia.Data;

public class GameResult
{
    public int Id { get; set; }

    public string HeroClass { get; set; } = "";

    public int EnemiesKilled { get; set; }

    public DateTime PlayedAt { get; set; }
}
