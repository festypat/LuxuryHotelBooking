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
    public class CategoryService
    {
        private readonly IRoomCategoryService _roomCategoryService;
        private readonly IMapper _mapper;
        public CategoryService(IRoomCategoryService roomCategoryService, IMapper mapper)
        {
            _roomCategoryService = roomCategoryService ?? throw new ArgumentNullException(nameof(roomCategoryService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<RoomCategoryViewModel> CreateCategory(RoomCategoryRequestDto model)
        {
            var entity = _mapper.Map<RoomCategoryRequestDto, RoomCategoryViewModel>(model);
            
            entity.CategoryId = ObjectId.GenerateNewId().ToString();
            entity.DateEntered = DateTime.Now;
            entity.LastDateModified = DateTime.Now;

            return await _roomCategoryService.AddAsync(entity);
        }

        public async Task<IEnumerable<RoomCategoryViewModel>> GetRoomCategories()
        {
            return await _roomCategoryService.GetAllAsync();           
        }
    }
}
