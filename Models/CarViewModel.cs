using System.ComponentModel.DataAnnotations;

public class CarViewModel
{
    public int CarID { get; set; }
    
    [Required(ErrorMessage = "İlan başlığı zorunludur")]
    [Display(Name = "İlan Başlığı")]
    public string? Title { get; set; }
    
    [Display(Name = "Görsel")]
    public IFormFile? ImageFile { get; set; }
    public string? ExistingImage { get; set; }
    
    [Required(ErrorMessage = "Marka seçimi zorunludur")]
    [Display(Name = "Marka")]
    public string? BrandCategory { get; set; }
    
    [Required(ErrorMessage = "Model zorunludur")]
    [Display(Name = "Model")]
    public string? Model { get; set; }
    
    [Required(ErrorMessage = "Tür seçimi zorunludur")]
    [Display(Name = "Tür")]
    public string? TypeCategory { get; set; }
    
    [Required(ErrorMessage = "Koltuk sayısı zorunludur")]
    [Display(Name = "Koltuk Sayısı")]
    public int Seats { get; set; }

    [Required(ErrorMessage = "Kira bedeli zorunludur")]
    public decimal RentPrice { get; set; }

    [Display(Name = "Aktif mi?")]
    [Required]
    public bool IsActive { get; set; }
}