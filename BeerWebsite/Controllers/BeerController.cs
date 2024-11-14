using BeerApp.BU.DTO;
using BeerApp.BU.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

[ApiController]
[Route("[controller]")]
public class BeerController : ControllerBase
{
    private readonly IBeerService _beerService;

    public BeerController(IBeerService beerService)
    {
        _beerService = beerService;
    }

    [HttpGet("Beers")] 
    public async Task<IActionResult> GetAllBeers()
    {
        var result = await _beerService.GetAllBeers();
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("AddBeer")]
    public async Task<IActionResult> CreateBeer([FromBody] CreateBeerDTO model)
    {
        var result = await _beerService.CreateBeer(model);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpGet("SearchBeer")]
    public async Task<IActionResult> SearchByName(string name)
    {
        var result = await _beerService.SearchByName(name);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPut("{beerId}/AddRating")]
    public async Task<IActionResult> RateBeer(int beerId, [FromBody] int rating)
    {
        if (rating < 1 || rating > 5)
        {
            return BadRequest("Rating must be between 1 and 5.");
        }

        var response = await _beerService.UpdateRating(beerId, rating);
        if (response.IsSuccess)
        {
            return Ok(response.Data);
        }
        return BadRequest(response.Message);
    }


}
