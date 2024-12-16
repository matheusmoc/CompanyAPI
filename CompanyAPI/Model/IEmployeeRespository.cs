namespace CompanyAPI.Model
{
    public interface IEmployeeRespository
    {
        void Add(Employee employee);

        List<Employee> GetAll();
    }
}
