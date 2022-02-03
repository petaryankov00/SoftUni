using SMS.Models;
using SMS.ViewModels;
using System.Collections.Generic;

namespace SMS.Services
{
    public interface IProductService
    {
        UserProductsViewModel GetAllProductsWithUser(string userId);

        bool CreateProduct(CreateProductInputModel model);

        IEnumerable<ProductsInCartViewModel> GetProductsInCart(string userId);

        bool AddProductInUserCart(string productId,string userId);

        void ClearProductsInCart(string userId);
    }
}
