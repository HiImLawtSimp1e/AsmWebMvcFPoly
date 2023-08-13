using ASM_hungnqph19112_CS4.Data;

namespace ASM_hungnqph19112_CS4.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAll()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }
    }
}
