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
    public class RoomService : IRoomService
    {
        private readonly IMongoCollection<Rooms> _rooms;
        private readonly IMapper _mapper;
        public RoomService(ILuxuryDatabaseSettings settings, IMapper mapper)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _rooms = database.GetCollection<Rooms>(settings.RoomsCollectionName);
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<RoomViewModel>> GetAllAsync()
        {
            var categories = await _rooms.Find(s => true).ToListAsync();

            return _mapper.Map<IEnumerable<Rooms>, IEnumerable<RoomViewModel>>(categories);
        }
        public async Task<RoomViewModel> GetByIdAsync(string id)
        {
            var category = await _rooms.Find<Rooms>(s => s.CategoryId == id).FirstOrDefaultAsync();

            return _mapper.Map<Rooms, RoomViewModel>(category);
        }
        public async Task<RoomViewModel> AddAsync(RoomViewModel model)
        {
            var entity = _mapper.Map<RoomViewModel, Rooms>(model);

            await _rooms.InsertOneAsync(entity);

            return model;
        }
        public async Task UpdateAsync(string id, RoomViewModel model)
        {
            var entity = _mapper.Map<RoomViewModel, Rooms>(model);

            await _rooms.ReplaceOneAsync(s => s.CategoryId == id, entity);
        }
        public async Task DeleteAsync(string id)
        {
            await _rooms.DeleteOneAsync(s => s.CategoryId == id);
        }
    }
}
