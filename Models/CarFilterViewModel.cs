using TechcareerBootcampFest4Project.Entity;

namespace TechcareerBootcampFest4Project.Models{

    public class CarFilterViewModel
    {
        public List<Car> Cars { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }    
}