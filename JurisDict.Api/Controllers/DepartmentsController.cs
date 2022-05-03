using JurisDict.Api.Repositories.Interfaces;
using AutoMapper;
using Common.DTOs;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Common.Exceptions;
using Common.Defaults;

namespace JurisDict.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IRepository<Department> _departments;
        private readonly Mapper _mapper;

        public DepartmentsController(IRepository<Department> departments, Mapper mapper)
        {
            this._departments = departments;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DepartmentResponse>> Get()
        {
            try
            {
                return _mapper.Map<IEnumerable<DepartmentResponse>>(await _departments.GetAllAsync());
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        public async Task<DepartmentResponse> Post(DepartmentRequest departmentRequest)
        {
            try
            {
                var department = _mapper.Map<Department>(departmentRequest);
                return _mapper.Map<DepartmentResponse>(await _departments.CreateAsync(department));
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public async Task<IEnumerable<DepartmentResponse>> Put(IEnumerable<DepartmentRequest> departmentRequests)
        {
            try
            {
                var departments = _mapper.Map<IEnumerable<Department>>(departmentRequests);
                return _mapper.Map<IEnumerable<DepartmentResponse>>(await _departments.UpdateAsync(departments));
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
                return await _departments.DeleteAsync(ids);
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}