using ASM_hungnqph19112_CS4.Data;
using ASM_hungnqph19112_CS4.Services.CategoryService;
using ASM_hungnqph19112_CS4.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace ASM_hungnqph19112_CS4.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {

        private DataContext _context;
        private readonly ICategoryService _service;
        public CategoryViewComponent()
        {
            _context = new DataContext();
            _service = new CategoryService(_context);
        }
        public IViewComponentResult Invoke()
        {
            var categories = _service.GetAll()
                .OrderBy(x => x.Title);
            return View(categories);
        }
    }
}
