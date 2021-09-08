using AutoMapper;
using Luxury.Application.Core.Interfaces.Services;
using Luxury.Helper.Dto.Request;
using Luxury.Helper.ViewModel;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Luxury.Application.Core.APIServices
{
    public class ReservationAPIService
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        public ReservationAPIService(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ReservationViewModel> BookRoomAsync(ReservationRequestDto model)
        {
            var entity = _mapper.Map<ReservationRequestDto, ReservationViewModel>(model);
            
            entity.ReservationId = ObjectId.GenerateNewId().ToString();
            entity.ReservationDate = DateTime.Now;
            entity.LastDateModified = DateTime.Now;

            return await _reservationService.AddAsync(entity);
        }

        public async Task<IEnumerable<ReservationViewModel>> GetReservations()
        {
            return await _reservationService.GetAllAsync();           
        }
    }
}
