using System.ComponentModel.DataAnnotations.Schema;

namespace TechcareerBootcampFest4Project.Entity{

    public class User{

        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}