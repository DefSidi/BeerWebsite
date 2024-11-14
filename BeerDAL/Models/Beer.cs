using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerApp.DAL.Models;

public sealed record Beer
{
    public int BeerId { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal? AverageRating { get; set; }

    public List<Rating>? Ratings { get; set; }

}
