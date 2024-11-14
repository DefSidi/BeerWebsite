using BeerApp.DAL.Context;
using BeerApp.DAL.Interfaces;
using BeerApp.DAL.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BeerApp.DAL.Repository;

public class BeerRepository : IBeerRepository
{
    private readonly DbBeerContext _context;
    public BeerRepository(DbBeerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Beer>> GetAllAsync()
    {
        return await _context.Beers.ToListAsync();
    }

    public async Task CreateBeerAsync(Beer beer)
    {
        await _context.AddAsync(beer);
        _context.SaveChanges();

    }
    public async Task<IEnumerable<Beer>> SearchByNameAsync(string name)
    {
        var result = await _context.Beers
        .Where(b => b.Name.ToLower().Contains(name.ToLower()))
        .ToListAsync();
        return result;

    }
    public async Task<Beer> GetBeerByIdAsync(int id)
    {
        return await _context.Beers.FirstOrDefaultAsync(xx => xx.BeerId == id);
    }

    public async Task UpdateBeerAsync(Beer beer)
    {
        _context.Beers.Update(beer);
        await _context.SaveChangesAsync();
    }

    public async Task AddRatingAsync(int beerId, int rating)
    {
        var beer = await _context.Beers.FirstOrDefaultAsync(b => b.BeerId == beerId);
        if (beer == null) throw new KeyNotFoundException("Beer not found");

        var newRating = new Rating
        {
            BeerId = beerId,
            RatingValue = rating,
            RatingTimestamp = DateTime.Now
        };
        _context.Ratings.Add(newRating);

        await _context.SaveChangesAsync();

        var listofBeersRating = (decimal) await _context.Ratings.Where(a => a.BeerId == beerId).Select(a => a.RatingValue).AverageAsync(); 

        beer.AverageRating = listofBeersRating;
        _context.Beers.Update(beer);
        await _context.SaveChangesAsync();
    }

}
