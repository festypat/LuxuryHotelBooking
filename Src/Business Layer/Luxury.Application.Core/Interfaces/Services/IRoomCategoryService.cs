using Luxury.Helper.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Luxury.Application.Core.Interfaces.Services
{
    public interface IRoomCategoryService
    {
        Task<RoomCategoryViewModel> AddAsync(RoomCategoryViewModel model);
        Task DeleteAsync(string id);
        Task<IEnumerable<RoomCategoryViewModel>> GetAllAsync();
        Task<RoomCategoryViewModel> GetByIdAsync(string id);
        Task UpdateAsync(string id, RoomCategoryViewModel model);
    }
}
