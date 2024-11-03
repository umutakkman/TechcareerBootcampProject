using TechcareerBootcampFest4Project.Entity;

namespace TechcareerBootcampFest4Project.Models{

    public class CarFilterViewModel
    {
        public List<Car> Cars { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }    
}