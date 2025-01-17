using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailDescriptionComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailDescriptionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var productClient = _httpClientFactory.CreateClient();
            var productResponse = await productClient.GetAsync("https://localhost:7070/api/ProductDetails/GetProductDetailByProductId/" + id);
            if (productResponse.IsSuccessStatusCode)
            {
                var productJsonData = await productResponse.Content.ReadAsStringAsync();
                var productDetails = JsonConvert.DeserializeObject<GetByIdProductDetailDto>(productJsonData);
                return View(productDetails);
            }

            return View();
        }
    }
}
