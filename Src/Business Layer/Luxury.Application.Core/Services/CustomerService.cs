using AutoMapper;
using Luxury.Application.Core.Contracts;
using Luxury.Application.Core.Interfaces.Services;
using Luxury.Domain.Entities;
using Luxury.Helper.ViewModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Luxury.Application.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customer;
        private readonly IMapper _mapper;
        public CustomerService(ILuxuryDatabaseSettings settings, IMapper mapper)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _customer = database.GetCollection<Customer>(settings.CustomerCollectionName);
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAllAsync()
        {
            var customers = await _customer.Find(s => true).ToListAsync();

            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);
        }
        public async Task<CustomerViewModel> GetByIdAsync(string id)
        {
            var customer = await _customer.Find<Customer>(s => s.CustomerId == id).FirstOrDefaultAsync();

            return _mapper.Map<Customer, CustomerViewModel>(customer);
        }
        public async Task<CustomerViewModel> AddAsync(CustomerViewModel model)
        {
            var entity = _mapper.Map<CustomerViewModel, Customer>(model);

            await _customer.InsertOneAsync(entity);

            return model;
        }
        public async Task UpdateAsync(string id, CustomerViewModel model)
        {
            var entity = _mapper.Map<CustomerViewModel, Customer>(model);

            await _customer.ReplaceOneAsync(s => s.CustomerId == id, entity);
        }
        public async Task DeleteAsync(string id)
        {
            await _customer.DeleteOneAsync(s => s.CustomerId == id);
        }
    }
}
