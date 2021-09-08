using Luxury.Application.Core.APIServices;
using Luxury.Helper.Dto.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Luxury.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        private readonly RoomsService _roomsService;
        public AdminController(CategoryService categoryService, RoomsService roomsService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _roomsService = roomsService ?? throw new ArgumentNullException(nameof(roomsService));
        }

        [HttpPost]
        [Route("create-room-category")]
        public async Task<IActionResult> CreateRoomCategory([FromBody] RoomCategoryRequestDto model)
        {
            var response = await _categoryService.CreateCategory(model);

            return Ok(response);
        }


        [HttpGet]
        [Route("get-room-category")]
        public async Task<IActionResult> Get()
        {
            var response = await _categoryService.GetRoomCategories();

            return Ok(response);
        }

        [HttpPost]
        [Route("create-room")]
        public async Task<IActionResult> CreateRooms([FromBody] CreateRoomRequestDto model)
        {
            var response = await _roomsService.CreateRoom(model);

            return Ok(response);
        }

    }
}
