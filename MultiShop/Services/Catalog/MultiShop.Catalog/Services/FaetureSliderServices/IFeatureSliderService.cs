using MultiShop.Catalog.DTOs.FeatureSliderDTOs;


namespace MultiShop.Catalog.Services.FaetureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFaetureSliderAsync();
        Task CreateFaetureSliderAsync(CreateFeatureSliderDto createFaetureSliderDto);
        Task UpdateFaetureSliderAsync(UpdateFeatureSliderDto updateFaetureSliderDto);
        Task DeleteFaetureSliderAsync(string id);

        Task<GetByIdFeatureSliderDto> GetByIdFaetureSliderAsync(string id);

        Task FeatureSliderChangeStatusToTrue(string id);
        Task FeatureSliderChangeStatusToFalse(string id);
    }
}
