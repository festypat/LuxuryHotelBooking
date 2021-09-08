using Luxury.Application.Core.APIServices;
using Luxury.Application.Core.Interfaces.Services;
using Luxury.Application.Core.Services;
using Luxury.Helper.AutoMapperSettings;
using Microsoft.Extensions.DependencyInjection;

namespace Luxury.Extensions.Dependencies
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddScoped<IRoomCategoryService, RoomCategoryService>();
            services.AddScoped<CategoryService>();

            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<RoomsService>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<CustomerAPIService>();

            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<ReservationAPIService>();


            return services;
        }
    }
}
