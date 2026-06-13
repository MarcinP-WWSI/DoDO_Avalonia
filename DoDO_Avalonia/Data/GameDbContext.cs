using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace DoDO.Avalonia.Data;

public class GameDbContext : DbContext
{
    public DbSet<GameResult> Results => Set<GameResult>();

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(
            "Data Source=dodo.db");
    }
}
