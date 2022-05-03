using Common.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JurisDict.Wpf.API;
using JurisDict.Wpf.Services.Interfaces;

namespace JurisDict.Wpf.Services
{
    public class DepartmentsService : IDepartmentsProvider
    {
        private readonly IDepartmentApi _department;

        public DepartmentsService(ApiSettings apiSettings)
        {
            _department = RestService.For<IDepartmentApi>(apiSettings.Host, apiSettings.RefitSettings);
        }

        public async Task<DepartmentResponse> Create(Department department)
        {
            return await _department.AddDepartment(department).ConfigureAwait(false);
        }

        public async Task<IEnumerable<DepartmentResponse>> Read()
        {
            return await _department.GetDepartments().ConfigureAwait(false);
        }

        public async Task<IEnumerable<DepartmentResponse>> Update(IEnumerable<Department> models)
        {
            return await _department.UpdateDepartments(models).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Guid>> Delete(IEnumerable<Guid> ids)
        {
            return await _department.DeleteDepartments(ids).ConfigureAwait(false);
        }

        public Task<DepartmentResponse> ReadRelatedTables()
        {
            throw new NotImplementedException();
        }
    }
}
