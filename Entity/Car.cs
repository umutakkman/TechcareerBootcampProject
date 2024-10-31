namespace TechcareerBootcampFest4Project.Entity{

    public class Car{

        public int CarID { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Brand { get; set; }
        public string? Type { get; set; }
        public string? Model { get; set; }
        public string? Image { get; set; }
        public int Seats { get; set; }
        public decimal RentPrice { get; set; }
        public bool IsActive { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}