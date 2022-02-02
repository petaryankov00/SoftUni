namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SMS.Services;
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public HttpResponse Index()
        {
            if (this.User.IsAuthenticated)
            {
                var products = productService.GetAllProducts(this.User.Id);
                return this.View(products,"IndexLoggedIn");
            }

            return this.View();
        }
    }
}