using ASM_hungnqph19112_CS4.Data;
using ASM_hungnqph19112_CS4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace ASM_hungnqph19112_CS4.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public bool Add(ProductDto item)
        {
            try
            {
                var product = new Product
                {
                    Title = item.Title,
                    Price = item.Price,
                    Description = item.Description,
                    Infomation = item.Infomation,
                    ImageUrl = item.ImageUrl,
                    CategoryId = item.CategoryId
                };
                _context.Products.Add(product);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return false;
            _context.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Product> GetAll(int page)
        {
            var products = _context.Products
                .AsNoTracking()
                .OrderBy(x => x.Title);
            var result = ProductPagination(products, page);
            return result;
        }

        public IEnumerable<Product> GetByCategory(int categoryId, int page)
        {
            var products = _context.Products
              .AsNoTracking()
              .Where(x => x.CategoryId == categoryId)
              .OrderBy(x => x.Title);
            var result = ProductPagination(products, page);
            return result;
        }

        public Product GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            var images = _context.Images.Where(i => i.ProductId == id);
            return product;
        }

        public bool Update(int id,ProductDto item)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return false;
            product.Title = item.Title;
            product.Description = item.Description;
            product.Infomation = item.Infomation;
            product.Price = item.Price;
            product.ImageUrl = item.ImageUrl;
            product.CategoryId = item.CategoryId;
            _context.Products.Update(product);
            _context.SaveChanges();
            return true;
        }

        private IEnumerable<Product> ProductPagination(dynamic products, int page)
        {
            int pageSize = 8;
            int pageNumber;
            if (page == 0 || page == null)
            {
                pageNumber = 1;
                page = 1;
            }
            else
            {
                pageNumber = page;
            }
            PagedList<Product> result = new PagedList<Product>(products, pageNumber, pageSize);
            return result;
        }
    }
}
