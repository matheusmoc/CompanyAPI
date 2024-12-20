﻿using CompanyAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Infra
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

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _connectionContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetAsync(int id)
        {
            var employee = await _connectionContext.Employees.FindAsync(id);
            return employee ?? throw new KeyNotFoundException($"Employee with id {id} not found");
        }

    }
}