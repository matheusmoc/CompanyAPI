using CompanyAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(
                "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;"
            ));
        }
    }
}
