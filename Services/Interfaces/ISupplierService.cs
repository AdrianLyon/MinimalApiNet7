
using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<List<Supplier>> GetAllAsync();
        Task<Supplier> GetAsync(int id);
        Task<Supplier> CreateAsync(Supplier supplier);
        Task<bool> UpdateAsync(Supplier supplier);
        Task<bool> DeleteAsync(Supplier supplier);
    }
}