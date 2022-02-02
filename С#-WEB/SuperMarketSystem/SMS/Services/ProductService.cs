using SMS.Data;
using SMS.Data.Models;
using SMS.Models;
using SMS.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly SMSDbContext dbContext;

        public ProductService(SMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreateProduct(CreateProductInputModel model)
        {
            if (!isValid(model))
            {
                return false;
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
            };

            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            return true;
        }

        public ICollection<AllProductsViewModel> GetAllProducts(string userId)
        {
            var username = GetCurrentUserName(userId);

            var products =
                dbContext
                .Products
                .Select(x => new AllProductsViewModel
                {
                    Name = x.Name,
                    Price = x.Price.ToString("f2"),
                    Username = username,
                    ProductId = x.Id,
                })
                .ToList();

            if (products.Count == 0)
            {
                products.Add(new AllProductsViewModel { Username = username });
            }

            return products;
        }
        private bool isValid(CreateProductInputModel model)
        {
            if (model.Name == null || model.Name.Length < 4 || model.Name.Length > 20)
            {
                return false;
            }
            if (model.Price < 0.05M || model.Price > 1000M)
            {
                return false;
            }

            return true;
        }

        private string GetCurrentUserName(string userId)
               => this.dbContext.Users.FirstOrDefault(x => x.Id == userId).Username;
    }
}
