namespace CarRentalWebsite.Models;

public class Category
{
    public int CategoryID { get; set; }
    public string? TypeCategory { get; set; }
    public string? BrandCategory { get; set; }
    public int? SeatCategory { get; set; }
    public List<Car> Cars { get; set; } = new();
}