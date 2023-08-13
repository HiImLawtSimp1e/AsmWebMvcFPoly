using ASM_hungnqph19112_CS4.Data;
using ASM_hungnqph19112_CS4.Models;

namespace ASM_hungnqph19112_CS4.Services.ProductService
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll(int page);
        IEnumerable<Product> GetByCategory(int categoryId, int page);
        Product GetById(int id);
        bool Add(ProductDto product);
        bool Update(int id,ProductDto product);
        bool Delete(int id);
    }
}
