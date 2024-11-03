using System.ComponentModel.DataAnnotations;

namespace TechcareerBootcampFest4Project.Entity{

    public class Car{

        public int CarID { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Url { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public string? Model { get; set; }
        public string? Image { get; set; }
        [Required]
        public int Seats { get; set; }
        [Required]
        public decimal RentPrice { get; set; }
        public bool IsActive { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}