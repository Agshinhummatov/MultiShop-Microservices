using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailReviewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var productClient = _httpClientFactory.CreateClient();
            var productResponse = await productClient.GetAsync("https://localhost:7075/api/Comments/CommentListByProductId/" + id);
            if (productResponse.IsSuccessStatusCode)
            {
                var productJsonData = await productResponse.Content.ReadAsStringAsync();
                var productDetails = JsonConvert.DeserializeObject<List<ResultCommentDto>>(productJsonData);
                return View(productDetails);
            }

            return View();
        }
    }
    
}
