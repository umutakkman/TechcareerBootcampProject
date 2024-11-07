using System.ComponentModel.DataAnnotations;

namespace TechcareerBootcampFest4Project.Models{

    public class RegisterViewModel{

        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        [MinLength(3, ErrorMessage = "Kullanıcı adı en az 3 karakter olmalıdır")]
        [MaxLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olmalıdır")]
        [Display(Name = "Kullanıcı Adı")]
        [DataType(DataType.Text)]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır")]
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