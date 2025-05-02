using System.ComponentModel.DataAnnotations;

namespace CarRentalWebsite.ViewModels;
public class CarViewModel
{
    public int CarID { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [Display(Name = "Title")]
    public string? Title { get; set; }

    [Display(Name = "Image")] public IFormFile? ImageFile { get; set; }

    public string? ExistingImage { get; set; }

    [Required(ErrorMessage = "Brand selection is required")]
    [Display(Name = "Brand")]
    public string? BrandCategory { get; set; }

    [Required(ErrorMessage = "Model selection is required")]
    [Display(Name = "Model")]
    public string? Model { get; set; }

    [Required(ErrorMessage = "Brand selection is required")]
    [Display(Name = "Type")]
    public string? TypeCategory { get; set; }

    [Required(ErrorMessage = "Seat number selection is required")]
    [Display(Name = "Seat number")]
    public int Seats { get; set; }

    [Required(ErrorMessage = "Seat number selection is required")]
    public decimal RentPrice { get; set; }

    [Display(Name = "Is it available?")]
    [Required]
    public bool IsActive { get; set; }
}