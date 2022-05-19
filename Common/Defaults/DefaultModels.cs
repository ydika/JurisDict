using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Defaults
{
    public class DefaultModels
    {
        public Client Client { get; set; } = new Client()
        {
            Id = Guid.NewGuid(),
            FullName = "---",
            MobileNumber = "---",
            Address = "---",
            DateOfBirth = DateTime.Now,
            PassportData = "---",
            Gender = "-"
        };

        public Contract Contract { get; set; } = new Contract()
        {
            Id = Guid.NewGuid(),
            Client = new Client(),
            ContractNumber = "---",
            ConclusionDate = DateTime.Now,
            Status = false
        };

        public ContractService ContractService { get; set; } = new ContractService()
        {
            Id = Guid.NewGuid(),
            Contract = new Contract(),
            Service = new Service(),
            Employee = new Employee(),
            AppointmentDate = DateTime.Now,
            PerformanceDate = DateTime.Now
        };

        public Department Department { get; set; } = new Department()
        {
            Id = Guid.NewGuid(),
            DepartmentName = "---",
            Location = "---"
        };

        public Employee Employee { get; set; } = new Employee()
        {
            Id = Guid.NewGuid(),
            Department = new Department(),
            Position = new Position(),
            FullName = "---",
            MobileNumber = "---",
            Address = "---",
            DateOfBirth= DateTime.Now,
            Salary = 0.00,
            PassportData = "---",
            Experience = 0,
            Gender= "-"
        };

        public Position Position { get; set; } = new Position()
        {
            Id = Guid.NewGuid(),
            PositionName = "---",
            PositionType = "---",
            Description = "---"
        };

        public Service Service { get; set; } = new Service()
        {
            Id = Guid.NewGuid(),
            ServiceName = "---",
            ServiceDescription = "---",
            Price = 0.00
        };
    }
}
