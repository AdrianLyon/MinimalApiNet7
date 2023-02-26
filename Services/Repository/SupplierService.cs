using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services.Repository
{
    public class SupplierService : ISupplierService
    {
        private readonly MinimaldbContext _db;
        public SupplierService(MinimaldbContext db)
        {
            _db = db;
        }
        public async Task<List<Supplier>> GetAllAsync()
        {
            try
            {
                var suppliers =  await _db.Suppliers.ToListAsync();
                return suppliers;            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }
        public async Task<Supplier> GetAsync(int id)

        {
            try
            {
                var customer = await _db.Suppliers.FirstOrDefaultAsync(x => x.Id ==id);
                return customer;
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }
        public async Task<Supplier> CreateAsync(Supplier supplier)
        {
            try
            {
                _db.Suppliers.Add(supplier);
                await _db.SaveChangesAsync();
                return supplier;
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }
        public async Task<bool> DeleteAsync(Supplier supplier)
        {
            try
            {
                _db.Suppliers.Remove(supplier);
                await _db.SaveChangesAsync();
                return true; 
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }
        public async Task<bool> UpdateAsync(Supplier supplier)
        {
            try
            {
                _db.Suppliers.Update(supplier);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
        }
    }
}