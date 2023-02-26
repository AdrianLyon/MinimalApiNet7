
using AutoMapper;
using BackEnd.DTOs.CustomerDto;
using BackEnd.Models;
using BackEnd.Services.Interfaces;

namespace BackEnd.Modules
{
    public static class CustomerModule
    {
        public static void AddCustomersEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/customers", async (ICustomerService _customerService, IMapper _mapper) =>
            {
                var customerList = await _customerService.GetAllAsync();
                var customerListDto = _mapper.Map<List<CustomerListDto>>(customerList);
                if (customerListDto.Count > 0)
                {
                    return Results.Ok(customerListDto);
                }
                else
                {
                    return Results.NotFound("No customers found.");
                }
            }).WithTags("Customers");
            app.MapGet("/customers/{customerId}", async (ICustomerService _customerSevice, IMapper _mapper, int id) =>
            {
                var customer = await _customerSevice.GetAsync(id);
                var CustomerDto = _mapper.Map<CustomerListDto>(customer);
                if (customer is not null)
                    return Results.Ok(CustomerDto);
                else
                    return Results.NotFound("No customer found");
            }).WithTags("Customers");
            app.MapPost("/customers", async (ICustomerService _customerService, IMapper _mapper, CustomerCreateDto request) =>
            {
                var customer = _mapper.Map<Customer>(request);
                var customerDto = await _customerService.CreateAsync(customer);
                if (customerDto.Id != 0)
                    return Results.Ok(_mapper.Map<CustomerCreateDto>(customerDto));
                else
                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }).WithTags("Customers");
            app.MapPut("/customers/edit/{customerId}", async (ICustomerService _customerService, IMapper _mapper, int id, CustomerEditDto request) =>
            {
                var customerForUpdate = await _customerService.GetAsync(id);
                if (customerForUpdate is null) return Results.NotFound("No customer found");
                var customer = _mapper.Map<Customer>(request);
                customerForUpdate.FirstName = customer.FirstName;
                customerForUpdate.LastName = customer.LastName;
                customerForUpdate.City = customer.City;
                customerForUpdate.Country = customer.Country;
                customerForUpdate.Phone = customer.Phone;
                var response = await _customerService.UpdateAsync(customerForUpdate);
                if (response)
                    return Results.Ok(_mapper.Map<CustomerEditDto>(customerForUpdate));
                else
                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }).WithTags("Customers");
            app.MapDelete("/customer/delete/{id}", async (ICustomerService _customerService, int id) =>
            {
                var customerDelete = await _customerService.GetAsync(id);
                if (customerDelete is null) return Results.NotFound();
                var response = await _customerService.DeleteAsync(customerDelete);
                if (response)
                    return Results.Ok();
                else
                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }).WithTags("Customers");
        }
    }
}