using System.ComponentModel.DataAnnotations.Schema;

namespace TechcareerBootcampFest4Project.Entity{

    public class User{

        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? NameSurname { get; set; }
    }
}