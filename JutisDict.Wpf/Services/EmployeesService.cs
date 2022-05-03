using Common.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JurisDict.Wpf.API;
using JurisDict.Wpf.Services.Interfaces;
using Common.DTOs.Responses.CreateUpdateResponses;

namespace JurisDict.Wpf.Services
{
    public class EmployeesService : IEmployeesProvider
    {
        private readonly IEmployeeApi _employee;

        public EmployeesService(ApiSettings apiSettings)
        {
            _employee = RestService.For<IEmployeeApi>(apiSettings.Host, apiSettings.RefitSettings);
        }

        public async Task<EmployeeResponse> Create(Employee employee)
        {
            return await _employee.AddEmployee(employee).ConfigureAwait(false);
        }

        public async Task<IEnumerable<EmployeeResponse>> Read()
        {
            return await _employee.GetEmployees().ConfigureAwait(false);
        }

        public async Task<IEnumerable<EmployeeResponse>> Update(IEnumerable<Employee> models)
        {
            return await _employee.UpdateEmployees(models).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Guid>> Delete(IEnumerable<Guid> ids)
        {
            return await _employee.DeleteEmployees(ids).ConfigureAwait(false);
        }

        public async Task<EmployeeRelatedTablesResponse> ReadRelatedTables()
        {
            return await _employee.GetEmployeeRelatedTables().ConfigureAwait(false);
        }
    }
}
