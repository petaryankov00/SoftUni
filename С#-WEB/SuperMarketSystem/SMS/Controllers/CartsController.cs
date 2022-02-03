using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Services;

namespace SMS.Controllers
{
    [Authorize]
    public class CartsController : Controller
    {
        private readonly IProductService productService;

        public CartsController(IProductService productService)
        {
            this.productService = productService;
        }

        [Authorize]
        public HttpResponse Details()
        {
            var products = productService.GetProductsInCart(this.User.Id);
            return this.View(products);
        }

        [Authorize]
        public HttpResponse AddProduct(string productId)
        {
            var isProductAdded = productService.AddProductInUserCart(productId, this.User.Id);

            if (!isProductAdded)
            {
                return this.Text("Error");
            }

            return Redirect("/Carts/Details");
        }

        public HttpResponse Buy()
        {
            productService.ClearProductsInCart(this.User.Id);

            return Redirect("/");
        }
    }
}
