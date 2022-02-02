using SMS.Models;
using SMS.ViewModels;
using System.Collections.Generic;

namespace SMS.Services
{
    public interface IProductService
    {
        ICollection<AllProductsViewModel>  GetAllProducts(string userId);

        bool CreateProduct(CreateProductInputModel model);
    }
}
