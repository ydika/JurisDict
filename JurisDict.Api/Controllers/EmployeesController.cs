using JurisDict.Api.Repositories.Interfaces;
using AutoMapper;
using Common.DTOs;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Common.Defaults;
using Common.DTOs.Responses.CreateUpdateResponses;
using static Common.DTOs.Responses.CreateUpdateResponses.RelatedTables;

namespace JurisDict.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepository<Employee> _employees;

        private readonly IRepository<Department> _departments;
        private readonly IRepository<Position> _positions;

        private readonly Mapper _mapper;

        public EmployeesController(IRepository<Employee> employees, IRepository<Department> departments, IRepository<Position> positions, Mapper mapper)
        {
            this._employees = employees;
            this._departments = departments;
            this._positions = positions;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeResponse>> Get()
        {
            try
            {
                return _mapper.Map<IEnumerable<EmployeeResponse>>(await _employees.GetWithInclude(x => x.Department, x => x.Position));
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<EmployeeRelatedTablesResponse> GetRelatedTables()
        {
            try
            {
                EmployeeRelatedTablesResponse response = new()
                {
                    Employees = _mapper.Map<IEnumerable<EmployeeResponse>>(await _employees.GetAllAsync()),
                    Departments = _mapper.Map<IEnumerable<DepartmentRelatedTableResponse>>(await _departments.GetAllAsync()),
                    Positions = _mapper.Map<IEnumerable<PositionRelatedTableResponse>>(await _positions.GetAllAsync())
                };
                return response;
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        public async Task<EmployeeResponse> Post(EmployeeRequest employeeRequest)
        {
            try
            {
                var employee = _mapper.Map<Employee>(employeeRequest);
                employee.Department = await _departments.GetAsync(employee.DepartmentId);
                employee.Position = await _positions.GetAsync(employee.PositionId);
                return _mapper.Map<EmployeeResponse>(await _employees.CreateAsync(employee));
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public async Task<IEnumerable<EmployeeResponse>> Put(IEnumerable<EmployeeRequest> employeeRequests)
        {
            try
            {
                var employees = _mapper.Map<IEnumerable<Employee>>(employeeRequests);
                return _mapper.Map<IEnumerable<EmployeeResponse>>(await _employees.UpdateAsync(employees));
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        public async Task<IEnumerable<Guid>> Delete([FromBody]IEnumerable<Guid> ids)
        {
            try
            {
                return await _employees.DeleteAsync(ids);
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}