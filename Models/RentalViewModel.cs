using TechcareerBootcampFest4Project.Entity;

namespace TechcareerBootcampFest4Project.Models{

    public class RentalViewModel{

        public Car Car { get; set; } = new Car();
        public int CarId { get; set; }
        public int RentalDays { get; set; }
        public decimal TotalPrice { get; set; }
    }
}