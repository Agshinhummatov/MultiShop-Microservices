using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.FeatureSliderDTOs;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FaetureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionStrings);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFaetureSliderAsync(CreateFeatureSliderDto createFaetureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(createFaetureSliderDto);
             _featureSliderCollection.InsertOneAsync(value);
        }

        public Task DeleteFaetureSliderAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultFeatureSliderDto>> GetAllFaetureSliderAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdFeatureSliderDto> GetByIdFaetureSliderAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFaetureSliderAsync(UpdateFeatureSliderDto updateFaetureSliderDto)
        {
            throw new NotImplementedException();
        }
    }
}
