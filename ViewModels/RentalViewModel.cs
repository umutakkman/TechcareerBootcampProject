using CarRentalWebsite.Models;

namespace CarRentalWebsite.ViewModels;

public class RentalViewModel
{
    public Car Car { get; set; } = new();
    public int CarId { get; set; }
    public int RentalDays { get; set; }
    public decimal TotalPrice { get; set; }
}