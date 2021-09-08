using AutoMapper;
using Luxury.Application.Core.Contracts;
using Luxury.Application.Core.Interfaces.Services;
using Luxury.Domain.Entities;
using Luxury.Helper.ViewModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Luxury.Application.Core.Services
{
    public class RoomCategoryService : IRoomCategoryService
    {
        private readonly IMongoCollection<RoomCategory> _category;
        private readonly IMapper _mapper;
        public RoomCategoryService(ILuxuryDatabaseSettings settings, IMapper mapper)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _category = database.GetCollection<RoomCategory>(settings.CategoryCollectionName);
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<RoomCategoryViewModel>> GetAllAsync()
        {
            var categories = await _category.Find(s => true).ToListAsync();

            return _mapper.Map<IEnumerable<RoomCategory>, IEnumerable<RoomCategoryViewModel>>(categories);
        }
        public async Task<RoomCategoryViewModel> GetByIdAsync(string id)
        {
            var category = await _category.Find<RoomCategory>(s => s.CategoryId == id).FirstOrDefaultAsync();

            return _mapper.Map<RoomCategory, RoomCategoryViewModel>(category);
        }
        public async Task<RoomCategoryViewModel> AddAsync(RoomCategoryViewModel model)
        {
            var entity = _mapper.Map<RoomCategoryViewModel, RoomCategory>(model);

            await _category.InsertOneAsync(entity);

            return model;
        }
        public async Task UpdateAsync(string id, RoomCategoryViewModel model)
        {
            var entity = _mapper.Map<RoomCategoryViewModel, RoomCategory>(model);

            await _category.ReplaceOneAsync(s => s.CategoryId == id, entity);
        }
        public async Task DeleteAsync(string id)
        {
            await _category.DeleteOneAsync(s => s.CategoryId == id);
        }
    }
}
