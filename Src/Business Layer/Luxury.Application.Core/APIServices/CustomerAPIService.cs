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
    public class CustomerAPIService
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerAPIService(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CustomerViewModel> RegisterCustomerAsync(RegisterCustomerDto model)
        {
            var entity = _mapper.Map<RegisterCustomerDto, CustomerViewModel>(model);
            
            entity.CustomerId = ObjectId.GenerateNewId().ToString();
            entity.DateRegistered = DateTime.Now;
            entity.LastDateModified = DateTime.Now;

            return await _customerService.AddAsync(entity);
        }

        public async Task<IEnumerable<CustomerViewModel>> GetCustomers()
        {
            return await _customerService.GetAllAsync();           
        }
    }
}
