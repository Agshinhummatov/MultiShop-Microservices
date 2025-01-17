using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailImageSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var productClient = _httpClientFactory.CreateClient();
            var productResponse = await productClient.GetAsync("https://localhost:7070/api/ProductImages/ProductImagesByProductId/" + id);
            if (productResponse.IsSuccessStatusCode)
            {
                var productJsonData = await productResponse.Content.ReadAsStringAsync();
                var productDetails = JsonConvert.DeserializeObject<GetByIdProductImageDto>(productJsonData);
                return View(productDetails);
            }

            return View();
        }

    }
}
