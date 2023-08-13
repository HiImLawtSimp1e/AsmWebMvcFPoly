using ASM_hungnqph19112_CS4.Data;
using ASM_hungnqph19112_CS4.Models;
using ASM_hungnqph19112_CS4.Models.Authentication;
using ASM_hungnqph19112_CS4.Services.ProductService;
using ASM_hungnqph19112_CS4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace ASM_hungnqph19112_CS4.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _context;
        private readonly IProductService _service;
        public HomeController()
        {
            _context = new DataContext();
            _service = new ProductService(_context);
        }
        [HttpGet]
        public ActionResult<List<Product>> Index(int page)
        {
            var result = _service.GetAll(page);

            return View(result);
        }
        [HttpGet]
        public ActionResult<List<Product>> ProductCategory(int id, int page)
        {
            var result = _service.GetByCategory(id, page);
            ViewBag.CategoryId = id;
            return View(result);
        }
        [HttpGet]
        public IActionResult Details (int id) 
        {
            var product = _service.GetById(id);
            List<Image> images = _context.Images
                .Where(i => i.ProductId == product.Id)
                .ToList();
            var productDetailsVM = new ProductDetailsViewModel {  
                Product = product, 
                Images = images 
            };
            return View(productDetailsVM);
        }

    }
}