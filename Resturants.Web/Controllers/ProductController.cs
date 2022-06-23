using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Resturants.Web.Models;
using Resturants.Web.Services.IServices;

namespace Resturants.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductApiData> list = new();
            var response = await _productService.GetAsync<ResponseApiData>();
            if (response != null && response.IsSuccess)
                list = JsonConvert.DeserializeObject<List<ProductApiData>>(Convert.ToString(response.Result));

            return View(list);
        }
    }
}
