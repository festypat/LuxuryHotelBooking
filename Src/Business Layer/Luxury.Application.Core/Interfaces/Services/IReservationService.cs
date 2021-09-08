using Luxury.Helper.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Luxury.Application.Core.Interfaces.Services
{
    public interface IReservationService
    {
        Task<ReservationViewModel> AddAsync(ReservationViewModel model);
        Task DeleteAsync(string id);
        Task<IEnumerable<ReservationViewModel>> GetAllAsync();
        Task<ReservationViewModel> GetByIdAsync(string id);
        Task UpdateAsync(string id, ReservationViewModel model);
    }
}
