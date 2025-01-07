using MultiShop.Catalog.DTOs.FeatureSliderDTOs;


namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFaetureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFaetureSliderDto);
        Task DeleteFeatureSliderAsync(string id);

        Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);

        Task FeatureSliderChangeStatusToTrue(string id);
        Task FeatureSliderChangeStatusToFalse(string id);
    }
}
