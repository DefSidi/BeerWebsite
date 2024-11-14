using BeerApp.BU.DTO;
using BeerApp.DAL.Models;

namespace BeerApp.BU.Interfaces;
public interface IBeerService
{
    Task<ApiResponse<IEnumerable<BeerDTO>>> GetAllBeers();
    Task<ApiResponse<BeerDTO>> CreateBeer(CreateBeerDTO model);
    Task<ApiResponse<IEnumerable<BeerDTO>>> SearchByName(string name);
    Task<ApiResponse<BeerDTO>> UpdateRating(int beerId, int newRating);


}
