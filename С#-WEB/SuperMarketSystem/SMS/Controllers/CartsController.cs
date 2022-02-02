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

        public HttpResponse Details()
        {
            var products = productService.GetProductsInCart(this.User.Id);
            return this.View(products);
        }
    }
}
