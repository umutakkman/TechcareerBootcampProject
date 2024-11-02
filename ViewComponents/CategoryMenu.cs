using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechcareerBootcampFest4Project.Data.Abstract;

namespace TechcareerBootcampFest4Project.ViewComponents{

    public class CategoryMenu : ViewComponent{

        private ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(){
            return View(await _categoryRepository.Categories.ToListAsync());
        }
    }
}