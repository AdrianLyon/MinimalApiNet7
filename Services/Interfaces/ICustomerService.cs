using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetAsync(int id);
        Task<Customer> CreateAsync(Customer customer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(Customer customer);
    }
}