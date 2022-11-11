using Microsoft.AspNetCore.Mvc;
using PHCleanArchSample.Application.Interfaces;

namespace PHCleanArchSample.WebMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _productService.GetProducts();
            return View(categories);
        }
    }
}
