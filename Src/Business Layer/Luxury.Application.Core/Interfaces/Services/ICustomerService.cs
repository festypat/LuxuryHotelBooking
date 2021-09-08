using Luxury.Helper.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Luxury.Application.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<CustomerViewModel> AddAsync(CustomerViewModel model);
        Task DeleteAsync(string id);
        Task<IEnumerable<CustomerViewModel>> GetAllAsync();
        Task<CustomerViewModel> GetByIdAsync(string id);
        Task UpdateAsync(string id, CustomerViewModel model);
    }
}
