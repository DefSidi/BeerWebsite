namespace BeerApp.DAL.Models;

public sealed record  Rating
{
    public int RatingId { get; set; }
    public int BeerId { get; set; }
    public int RatingValue { get; set; }
    public DateTime RatingTimestamp { get; set; }

    public Beer? Beer { get; set; }
}
