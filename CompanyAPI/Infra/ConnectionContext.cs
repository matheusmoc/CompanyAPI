using CompanyAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
        }
    }
}
