using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Models;
using SMS.Services;

namespace SMS.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public HttpResponse Create()
            => this.View();

        [HttpPost]
        public HttpResponse Create(CreateProductInputModel model)
        {
            var isCreated = productService.CreateProduct(model);
            if (!isCreated)
            {
                return this.Text("Invalid product.");
            }
            return this.Redirect("/");
        }
    }
}
