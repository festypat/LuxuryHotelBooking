using Luxury.Helper.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Luxury.Application.Core.Interfaces.Services
{
    public interface IRoomService
    {
        Task<RoomViewModel> AddAsync(RoomViewModel model);
        Task DeleteAsync(string id);
        Task<IEnumerable<RoomViewModel>> GetAllAsync();
        Task<RoomViewModel> GetByIdAsync(string id);
        Task UpdateAsync(string id, RoomViewModel model);
    }
}
