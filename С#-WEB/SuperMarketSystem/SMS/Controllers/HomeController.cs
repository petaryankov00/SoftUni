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
                var userAndProducts = productService.GetAllProductsWithUser(this.User.Id);
                return this.View(userAndProducts, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}