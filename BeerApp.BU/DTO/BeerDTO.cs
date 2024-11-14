namespace BeerApp.BU.DTO;

public class BeerDTO
{
    public int BeerId { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public decimal AverageRating { get; set; }
}
