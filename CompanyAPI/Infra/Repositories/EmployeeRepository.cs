using CompanyAPI.Domain.DTOs;
using CompanyAPI.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CompanyAPI.Infra.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _connectionContext;

        public EmployeeRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public async Task AddAsync(Employee employee)
        {
            await _connectionContext.Employees.AddAsync(employee);
            await _connectionContext.SaveChangesAsync();
        }

        public async Task<List<EmployeeDTO>> GetAllAsync(int pageNumber, int pageQuantity)
        {
            return await _connectionContext.Employees
                .Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select(e => new EmployeeDTO()
            {
                Id = e.Id,
                Name = e.Name,
                Photo = e.Photo,
                Phone = e.Phone,
                Address = e.Address,
                City = e.City,
                Region = e.Region,
                PostalCode = e.PostalCode,
                Country = e.Country,

            }).ToListAsync();
        }

        public async Task<Employee> GetAsync(int id)
        {
            return await _connectionContext.Employees.FindAsync(id) ?? throw new KeyNotFoundException($"Employee with id {id} not found");
        }

    }
}