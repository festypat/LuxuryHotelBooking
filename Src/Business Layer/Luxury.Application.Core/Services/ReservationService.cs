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
    public class ReservationService : IReservationService
    {
        private readonly IMongoCollection<Reservation> _reservation;
        private readonly IMapper _mapper;
        public ReservationService(ILuxuryDatabaseSettings settings, IMapper mapper)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _reservation = database.GetCollection<Reservation>(settings.ReservationCollectionName);
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ReservationViewModel>> GetAllAsync()
        {
            var reservations = await _reservation.Find(s => true).ToListAsync();

            return _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationViewModel>>(reservations);
        }
        public async Task<ReservationViewModel> GetByIdAsync(string id)
        {
            var Reservation = await _reservation.Find<Reservation>(s => s.ReservationId == id).FirstOrDefaultAsync();

            return _mapper.Map<Reservation, ReservationViewModel>(Reservation);
        }
        public async Task<ReservationViewModel> AddAsync(ReservationViewModel model)
        {
            var entity = _mapper.Map<ReservationViewModel, Reservation>(model);

            await _reservation.InsertOneAsync(entity);

            return model;
        }
        public async Task UpdateAsync(string id, ReservationViewModel model)
        {
            var entity = _mapper.Map<ReservationViewModel, Reservation>(model);

            await _reservation.ReplaceOneAsync(s => s.ReservationId == id, entity);
        }
        public async Task DeleteAsync(string id)
        {
            await _reservation.DeleteOneAsync(s => s.ReservationId == id);
        }
    }
}
