

using BeerApp.DAL.Models;

namespace BeerApp.DAL.Interfaces;

public interface IBeerRepository
{
    Task<IEnumerable<Beer>> GetAllAsync();
    Task CreateBeerAsync(Beer beer);
    Task<IEnumerable<Beer>> SearchByNameAsync(string name);
    Task<Beer> GetBeerByIdAsync(int id);
    Task UpdateBeerAsync(Beer beer);
    Task AddRatingAsync(int beerId, int rating);
}
