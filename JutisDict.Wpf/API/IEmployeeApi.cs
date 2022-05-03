using Common.DTOs;
using Common.DTOs.Responses.CreateUpdateResponses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisDict.Wpf.API
{
    public interface IEmployeeApi
    {
        [Get("/api/employees/")]
        Task<IEnumerable<EmployeeResponse>> GetEmployees();
        [Get("/api/employees/getrelatedtables")]
        Task<EmployeeRelatedTablesResponse> GetEmployeeRelatedTables();
        [Post("/api/employees/")]
        Task<EmployeeResponse> AddEmployee(Employee employee);
        [Put("/api/employees/")]
        Task<IEnumerable<EmployeeResponse>> UpdateEmployees(IEnumerable<Employee> employees);
        [Delete("/api/employees/")]
        Task<IEnumerable<Guid>> DeleteEmployees([Body]IEnumerable<Guid> ids);
    }
}
