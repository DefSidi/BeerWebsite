using BeerApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerApp.DAL.Context;

public  class DbBeerContext : DbContext
{
    public DbBeerContext(DbContextOptions<DbBeerContext> options) : base(options)
    {
    }

    public DbSet<Beer> Beers { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beer>()
            .HasMany(b => b.Ratings)
            .WithOne(r => r.Beer)
            .HasForeignKey(r => r.BeerId);
    }
}

    
