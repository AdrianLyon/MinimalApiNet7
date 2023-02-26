
using AutoMapper;
using BackEnd.DTOs.CustomerDto;
using BackEnd.DTOs.SupplierDto;
using BackEnd.Models;

namespace BackEnd.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region CustomerProfile
            CreateMap<Customer, CustomerListDto>().ReverseMap();
            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
            CreateMap<Customer, CustomerEditDto>().ReverseMap();
            #endregion

            #region SupplierProfile
            CreateMap<Supplier, SupplierListDto>().ReverseMap();
            CreateMap<Supplier, SupplierCreateDto>().ReverseMap();
            CreateMap<Supplier, SupplierEditDto>().ReverseMap();
            #endregion
        }
    }
}