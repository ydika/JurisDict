using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace JurisDict.Api.DataBase
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractService> ContractServices { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Service> Services { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { 
        }
    }
}
