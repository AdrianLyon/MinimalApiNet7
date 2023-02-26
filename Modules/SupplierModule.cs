
using AutoMapper;
using BackEnd.DTOs.SupplierDto;
using BackEnd.Models;
using BackEnd.Services.Interfaces;

namespace BackEnd.Modules
{
    public static class SupplierModule
    {
        public static void AddSupplierEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/suppliers", async (ISupplierService supplierService, IMapper _mapper) =>
            {
                var supplier = await supplierService.GetAllAsync();
                var supplierDtos = _mapper.Map<List<SupplierListDto>>(supplier);
                if (supplierDtos.Count > 0)
                    return Results.Ok(supplierDtos);
                else
                    return Results.NotFound();
            }).WithTags("Suppliers");
            app.MapGet("/suppliers/{id}", async (ISupplierService supplierService, IMapper _mapper, int id) =>
            {
                var supplier = await supplierService.GetAsync(id);
                var supplierDto = _mapper.Map<SupplierListDto>(supplier);
                if (supplier is not null)
                    return Results.Ok(supplierDto);
                else
                    return Results.NotFound();
            }).WithTags("Suppliers");
            app.MapPost("/suppliers", async (ISupplierService supplierService, IMapper _mapper, SupplierCreateDto request) =>
            {
                var supplier = _mapper.Map<Supplier>(request);
                var supplierDto = await supplierService.CreateAsync(supplier);
                if (supplierDto.Id != 0)
                    return Results.Ok(_mapper.Map<SupplierCreateDto>(supplierDto));
                else
                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }).WithTags("Suppliers");
            app.MapPut("/suppliers/edit/{id}", async (ISupplierService supplierService, IMapper _mapper, int id, SupplierEditDto request) =>
            {
                var supplierForUpdate = await supplierService.GetAsync(id);
                if (supplierForUpdate is null) return Results.NotFound();
                var supplier = _mapper.Map<Supplier>(request);
                supplierForUpdate.CompanyName = supplier.CompanyName;
                supplierForUpdate.ContactName = supplier.ContactName;
                supplierForUpdate.City = supplier.City;
                supplierForUpdate.ContactTitle = supplier.ContactTitle;
                supplierForUpdate.Country = supplier.Country;
                supplierForUpdate.Fax = supplier.Fax;
                supplierForUpdate.Phone = supplier.Phone;
                var response = await supplierService.UpdateAsync(supplierForUpdate);
                if (response)
                    return Results.Ok(_mapper.Map<SupplierEditDto>(supplierForUpdate));
                else
                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }).WithTags("Suppliers");
            app.MapDelete("/suppliers/delete{id}", async (ISupplierService supplierService, IMapper _mapper, int id) =>
            {
                var supplerForDelete = await supplierService.GetAsync(id);
                if (supplerForDelete is null) return Results.NotFound();
                var response = await supplierService.DeleteAsync(supplerForDelete);
                if (response)
                    return Results.Ok();
                else
                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }).WithTags("Suppliers");
        }
    }
}