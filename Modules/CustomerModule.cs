
using AutoMapper;
using BackEnd.DTOs.CustomerDto;
using BackEnd.Services.Interfaces;

namespace BackEnd.Modules
{
    public static class CustomerModule
    {
        public static void AddCustomersEndPoints(this IEndpointRouteBuilder app){
            app.MapGet("/customers", async(ICustomerService _customerService, IMapper _mapper) =>{
                var customerList = await _customerService.GetAllAsync();
                var customerListDto = _mapper.Map<List<CustomerListDto>>(customerList);
                if(customerListDto.Count > 0){
                    return Results.Ok(customerListDto);
                }else{
                    return Results.NotFound("No customers found.");
                }
            });
        }
    }
}