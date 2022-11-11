using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PHCleanArchSample.Application.Interfaces;

namespace PHCleanArchSample.MVC.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
        
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }
    }
}