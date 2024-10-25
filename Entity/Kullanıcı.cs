using System.ComponentModel.DataAnnotations.Schema;

namespace TechcareerBootcampFest4Project.Entity{

    public class Kullanıcı{

        public int KullanıcıID { get; set; }
        public string? KullanıcıAdı { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }

        [ForeignKey("ArabaID")]
        public Araba? KiralananAraba { get; set; }
    }
}