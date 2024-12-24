using CompanyAPI.Domain.DTOs;

namespace CompanyAPI.Domain.Model
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee);
        Task<List<EmployeeDTO>> GetAllAsync(int pageNumber, int pageQuantity);

        Task<Employee> GetAsync(int id);
    }
}

