using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalWebsite.Data.Abstract;

namespace CarRentalWebsite.ViewComponents;

public class CategoryMenu : ViewComponent
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryMenu(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View(await _categoryRepository.Categories.ToListAsync());
    }
}