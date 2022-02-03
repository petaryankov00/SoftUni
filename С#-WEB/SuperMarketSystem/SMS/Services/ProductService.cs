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

        public UserProductsViewModel GetAllProductsWithUser(string userId)
        {
            var username = GetCurrentUserName(userId);

            var products = dbContext
                .Products
                .Select(x => new AllProductsViewModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    ProductId = x.Id
                })
                .ToList();

            var userAndProducts = new UserProductsViewModel
            {
                Username = username,
                Products = products
            };

            return userAndProducts;
        }
        public IEnumerable<ProductsInCartViewModel> GetProductsInCart(string userId)
        {
            var products = dbContext.Carts
                .Where(x => x.User.Id == userId)
                .Select(x => x
                .Products.
                 Select(p => new ProductsInCartViewModel
                 {
                     Name = p.Name,
                     Price = p.Price,
                 })).ToList()
                 .FirstOrDefault();

            return products;

        }

        public bool AddProductInUserCart(string productId, string userId)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.Id == productId);

            if (product == null)
            {
                return false;
            }

            var cart = dbContext.Carts.FirstOrDefault(x => x.User.Id == userId);

            cart.Products.Add(product);
            dbContext.SaveChanges();

            return true;
        }

        public void ClearProductsInCart(string userId)
        {
            var cartId = dbContext.Carts.FirstOrDefault(c => c.User.Id == userId).Id;


            var products = dbContext.Products
                .Where(x => x.CartId == cartId)
                .ToList();

            foreach (var p in products)
            {
                p.CartId = null;
            }

            dbContext.SaveChanges();                   
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
