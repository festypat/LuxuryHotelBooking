using AutoMapper;
using Luxury.Domain.Entities;
using Luxury.Helper.Dto.Request;
using Luxury.Helper.ViewModel;

namespace Luxury.Helper.AutoMapperSettings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RoomCategoryViewModel, RoomCategory>();
            CreateMap<RoomCategory, RoomCategoryViewModel>();          
            CreateMap<RoomCategoryRequestDto, RoomCategoryViewModel>();

            CreateMap<RoomViewModel, Rooms>();
            CreateMap<Rooms, RoomViewModel>();
            CreateMap<CreateRoomRequestDto, RoomViewModel>();

            CreateMap<CustomerViewModel, Customer>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<RegisterCustomerDto, CustomerViewModel>();

            CreateMap<ReservationViewModel, Reservation>();
            CreateMap<Reservation, ReservationViewModel>();
            CreateMap<ReservationRequestDto, ReservationViewModel>();
        }
    }
}
