namespace CompanyAPI.Model
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee); 

        Task<List<Employee>> GetAllAsync();

        Task<Employee> GetAsync(int id);
    }
}

