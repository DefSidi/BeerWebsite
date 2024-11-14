using Mapster;
using BeerApp.BU.DTO;
using BeerApp.BU.Interfaces;
using BeerApp.DAL.Interfaces;
using BeerApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BeerApp.BU.Services;

public class BeerService : IBeerService
{
    private readonly IBeerRepository _beerRepo;
    private readonly ILogger<BeerService> _logger;

    public BeerService(IBeerRepository beerRepo, ILogger<BeerService> logger)
    {
        _beerRepo = beerRepo;
        _logger = logger;
    }
    public ApiResponse<T> CreateSuccessResponse<T>(T data)
    {
        return new ApiResponse<T>
        {
            IsSuccess = true,
            Data = data,
            Message = "Operation succeeded"
        };
    }


    public ApiResponse<T> CreateErrorResponse<T>(string errorMessage)
    {
        return new ApiResponse<T>
        {
            IsSuccess = false,
            Message = errorMessage
        };
    }
    public async Task<ApiResponse<IEnumerable<BeerDTO>>> GetAllBeers()
    {
        try
        {
            var beers = await _beerRepo.GetAllAsync();
            var beersDto = beers.Adapt<IEnumerable<BeerDTO>>();
            return CreateSuccessResponse(beersDto); ;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting beers");
            return CreateErrorResponse<IEnumerable<BeerDTO>>("An error occurred.");
        }
    }

    public async Task<ApiResponse<IEnumerable<BeerDTO>>> SearchByName(string name)
    {
        try
        {
            var beers = await _beerRepo.SearchByNameAsync(name);
            var beersDto = beers.Adapt<IEnumerable<BeerDTO>>();
            return CreateSuccessResponse(beersDto); ;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while searching beers");
            return CreateErrorResponse<IEnumerable<BeerDTO>>("An error occurred.");
        }
    }
    public async Task<ApiResponse<BeerDTO>> CreateBeer(CreateBeerDTO model)
    {
        try
        {
            var beer = new Beer()
            {
                Name = model.Name,
                Type = model.Type
            };

            await _beerRepo.CreateBeerAsync(beer);

            var beerDto = beer.Adapt<BeerDTO>();
            return CreateSuccessResponse(beerDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating beer");
            return CreateErrorResponse<BeerDTO>("An error occurred while creating the beer.");
        }
    }


    public async Task<ApiResponse<BeerDTO>> UpdateRating(int beerId, int newRating)
    {
        try
        {
            await _beerRepo.AddRatingAsync(beerId, newRating);

            var updatedBeer = await _beerRepo.GetBeerByIdAsync(beerId);
            var beerDto = updatedBeer.Adapt<BeerDTO>();

            return CreateSuccessResponse(beerDto);
            
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating beer rating");
            return CreateErrorResponse<BeerDTO>("An error occurred while updating the rating.");
        }
    }


}
