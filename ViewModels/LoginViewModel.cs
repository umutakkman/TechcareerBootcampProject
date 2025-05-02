using System.ComponentModel.DataAnnotations;

namespace CarRentalWebsite.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Username cannot be empty")]
    [Display(Name = "Username")]
    [DataType(DataType.Text)]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password cannot be empty")]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}