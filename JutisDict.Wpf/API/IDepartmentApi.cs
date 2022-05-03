using Common.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisDict.Wpf.API
{
    public interface IDepartmentApi
    {
        [Get("/api/departments/")]
        Task<IEnumerable<DepartmentResponse>> GetDepartments();
        [Post("/api/departments/")]
        Task<DepartmentResponse> AddDepartment(Department department);
        [Put("/api/departments/")]
        Task<IEnumerable<DepartmentResponse>> UpdateDepartments(IEnumerable<Department> departments);
        [Delete("/api/departments/")]
        Task<IEnumerable<Guid>> DeleteDepartments([Body]IEnumerable<Guid> ids);
    }
}
