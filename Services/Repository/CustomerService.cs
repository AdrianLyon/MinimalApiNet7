
using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services.Repository
{
    public class CustomerService : ICustomerService
    {
        private readonly MinimaldbContext _db;
        public CustomerService(MinimaldbContext db)
        {
            _db = db;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            try
            {
                var customers = await _db.Customers.ToListAsync();
                return customers;
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }
        public async Task<Customer> GetAsync(int id)
        {
            try
            {
                var customer = await _db.Customers.FirstOrDefaultAsync(x => x.Id==id);
                return customer;
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }
        public async Task<Customer> CreateAsync(Customer customer)
        {
            try
            {
                _db.Customers.Add(customer);
                await _db.SaveChangesAsync();
                return customer;
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }
        public async Task<bool> UpdateAsync(Customer customer)
        {
            try
            {
                _db.Customers.Update(customer);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }
        public async Task<bool> DeleteAsync(Customer customer)
        {
            try
            {
                _db.Customers.Remove(customer);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}