namespace CompanyAPI.Domain.Model
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee);

        Task<List<Employee>> GetAllAsync(int pageNumber, int pageQuantity);

        Task<Employee> GetAsync(int id);
    }
}

