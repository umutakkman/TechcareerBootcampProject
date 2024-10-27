namespace TechcareerBootcampFest4Project.Entity{

    public class Category{

        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}