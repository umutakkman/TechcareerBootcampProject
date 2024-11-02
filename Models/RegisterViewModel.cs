using System.ComponentModel.DataAnnotations;

namespace TechcareerBootcampFest4Project.Models{

    public class RegisterViewModel{

        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        [Display(Name = "Kullanıcı Adı")]
        [DataType(DataType.Text)]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı boş geçilemez")]
        [Display(Name = "Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifreler uyuşmuyor")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email boş geçilemez")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Ad Soyad boş geçilemez")]
        [Display(Name = "Ad Soyad")]
        public string? NameSurname { get; set; }
    }
}