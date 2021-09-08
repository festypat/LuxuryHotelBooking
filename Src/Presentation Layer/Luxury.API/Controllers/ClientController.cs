using Luxury.Application.Core.APIServices;
using Luxury.Helper.Dto.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Luxury.API.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly CustomerAPIService _customerAPIService;
        private readonly RoomsService _roomsService;
        private readonly ReservationAPIService _reservationAPIService;
        public ClientController(CustomerAPIService customerAPIService, 
            RoomsService roomsService, ReservationAPIService reservationAPIService)
        {
            _customerAPIService = customerAPIService ?? throw new ArgumentNullException(nameof(customerAPIService));
            _roomsService = roomsService ?? throw new ArgumentNullException(nameof(roomsService));
            _reservationAPIService = reservationAPIService ?? throw new ArgumentNullException(nameof(reservationAPIService));
        }


        [HttpPost]
        [Route("register-customer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerDto model)
        {
            var response = await _customerAPIService.RegisterCustomerAsync(model);

            return Ok(response);
        }

        [HttpPost]
        [Route("book-room")]
        public async Task<IActionResult> BookRoom([FromBody] ReservationRequestDto model)
        {
            var response = await _reservationAPIService.BookRoomAsync(model);

            return Ok(response);
        }
    }
}
