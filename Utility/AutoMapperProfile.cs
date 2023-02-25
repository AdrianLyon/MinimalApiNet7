
using AutoMapper;
using BackEnd.DTOs.CustomerDto;
using BackEnd.Models;

namespace BackEnd.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region CustomerProfile
            CreateMap<Customer, CustomerListDto>().ReverseMap();
            #endregion
        }
    }
}