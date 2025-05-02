using System.ComponentModel.DataAnnotations;

namespace CarRentalWebsite.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Username cannot be empty")]
    [MinLength(3, ErrorMessage = "Username should be at least 3 characters long")]
    [MaxLength(50, ErrorMessage = "Username should be at most 50 characters long")]
    [Display(Name = "Username")]
    [DataType(DataType.Text)]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Username cannot be empty")]
    [MinLength(6, ErrorMessage = "Password should be at least 6 characters long")]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Password repetition cannot be empty")]
    [Display(Name = "Password repetition")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
    public string? ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Email cannot be empty")]
    [Display(Name = "Email")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Name and surname cannot be empty")]
    [Display(Name = "Name surname")]
    public string? NameSurname { get; set; }
}