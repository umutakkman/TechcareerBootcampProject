using Microsoft.AspNetCore.Mvc;
using TechcareerBootcampFest4Project.Data.Abstract;
using TechcareerBootcampFest4Project.Data.Concrete.EfCore;

namespace TechcareerBootcampFest4Project.Controllers{

    public class HomeController : Controller
    {
        private ICarRepository _repository;

        public HomeController(ICarRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.Cars.ToList());
        }
    }
}