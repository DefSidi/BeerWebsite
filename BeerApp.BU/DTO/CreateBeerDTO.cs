using System.ComponentModel.DataAnnotations;

namespace BeerApp.BU.DTO;

public record CreateBeerDTO
{
    public required string Name { get; set; }
    public required string Type { get; set; }

}
