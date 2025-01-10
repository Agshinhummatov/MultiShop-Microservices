using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Urunlerler";
            ViewBag.v3 = "Urun Listesi";
            ViewBag.vO = "Urun islemleri";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7070/api/Products");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);  

                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Urunlerler";
            ViewBag.v3 = "Urun Listesi";
            ViewBag.vO = "Urun Ekle";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value= x.CategoryId
                                                   }).ToList();

            ViewBag.CategoryValues = categoryValues;
            return View();
        }


        [HttpPost]
        [Route("CreateProduct")]
       
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createProductDto); 

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7070/api/Products", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });

            }

            return View();
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync("https://localhost:7070/api/Products?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            return View();

        }

        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Urunler";
            ViewBag.v3 = "Urunler Gunceleme Sayfasi";
            ViewBag.vO = "Urunler islemleri";
            var categoryClient = _httpClientFactory.CreateClient();
            var categoryResponse = await categoryClient.GetAsync("https://localhost:7070/api/Categories");
            var categoryJsonData = await categoryResponse.Content.ReadAsStringAsync();
            var categoryList = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJsonData);

        
            List<SelectListItem> categorySelectList = (from x in categoryList
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName,
                                                           Value = x.CategoryId
                                                       }).ToList();

            ViewBag.CategoryValues = categorySelectList;

            var productClient = _httpClientFactory.CreateClient();
            var productResponse = await productClient.GetAsync("https://localhost:7070/api/Products/" + id);
            if (productResponse.IsSuccessStatusCode)
            {
                var productJsonData = await productResponse.Content.ReadAsStringAsync();
                var productDetails = JsonConvert.DeserializeObject<UpdateProductDto>(productJsonData);
                return View(productDetails);
            }

            return View();

        }

        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/Products/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            return View();

        }

        [HttpGet]
        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Urunlerler";
            ViewBag.v3 = "Urun Listesi";
            ViewBag.vO = "Urun islemleri";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);

                return View(values);
            }
            return View();
        }


    }
}
