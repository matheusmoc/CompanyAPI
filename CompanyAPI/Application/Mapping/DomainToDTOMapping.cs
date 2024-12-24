using AutoMapper;
using CompanyAPI.Domain.DTOs;
using CompanyAPI.Domain.Model;

namespace CompanyAPI.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping() 
        {
            CreateMap<Employee, EmployeeDTO>();
        }
    }
}
