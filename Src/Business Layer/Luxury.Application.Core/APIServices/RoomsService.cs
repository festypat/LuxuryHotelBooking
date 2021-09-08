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
    public class RoomsService
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public RoomsService(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<RoomViewModel> CreateRoom(CreateRoomRequestDto model)
        {
            var entity = _mapper.Map<CreateRoomRequestDto, RoomViewModel>(model);
            
            entity.RoomId = ObjectId.GenerateNewId().ToString();
            entity.DateEntered = DateTime.Now;
            entity.LastDateModified = DateTime.Now;

            return await _roomService.AddAsync(entity);
        }

        public async Task<IEnumerable<RoomViewModel>> GetRooms()
        {
            return await _roomService.GetAllAsync();           
        }
    }
}
