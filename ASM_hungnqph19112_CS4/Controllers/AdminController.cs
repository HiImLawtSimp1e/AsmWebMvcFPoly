using ASM_hungnqph19112_CS4.Data;
using ASM_hungnqph19112_CS4.Models;
using ASM_hungnqph19112_CS4.Models.Authorization;
using ASM_hungnqph19112_CS4.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASM_hungnqph19112_CS4.Controllers
{
    [Authorization]
    [Route("admin")]
    public class AdminController : Controller
    {
        private DataContext _context;
        private readonly IProductService _productService;
        public AdminController()
        {
            _context = new DataContext();
            _productService = new ProductService(_context);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("product-list")]
        public ActionResult<List<Product>> ProductList(int page)
        {
            var result = _productService.GetAll(page);

            return View(result);
        }
        [HttpGet("product-create")]
        public IActionResult ProductCreate()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories.ToList(),
                "Id",
                "Title"
                );
            return View();
        }
        [HttpPost("product-create")]
        public IActionResult ProductCreate(ProductDto item)
        {
            if (_productService.Add(item))
            {
                return RedirectToAction("ProductList");
            }
            ViewBag.CategoryId = new SelectList(_context.Categories.ToList(),
             "Id",
             "Title"
             );
            return View(item);
        }
        [HttpGet("product-update/{id}")]
        public IActionResult ProductUpdate(int id)
        {
            ViewBag.CategoryId = new SelectList(_context.Categories.ToList(),
                "Id",
                "Title"
                );
            var item = _productService.GetById(id);
            ProductDto product = new ProductDto 
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                Infomation = item.Infomation,
                Price = item.Price,
                ImageUrl = item.ImageUrl,
                CategoryId = item.CategoryId,
            };
            return View(product);
        }
        [HttpPost("product-update/{id}")]
        public IActionResult ProductUpdate(ProductDto product)
        {
            if (_productService.Update(product.Id, product))
            {
                return RedirectToAction("ProductList");
            }
            ViewBag.CategoryId = new SelectList(_context.Categories.ToList(),
             "Id",
             "Title"
             );
            return View(product);
        }
        [HttpGet("product-delete/{id}")]
        public IActionResult ProductDelete(int id)
        {
            if (_productService.Delete(id))
            {
                return RedirectToAction("ProductList");
            }
            return View();
        }
    }
}
