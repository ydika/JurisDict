using JurisDict.Api.Repositories.Interfaces;
using AutoMapper;
using Common.DTOs;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Common.Exceptions;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Common.Defaults;

namespace JurisDict.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IRepository<Service> _services;
        private readonly Mapper _mapper;

        public ServicesController(IRepository<Service> services, Mapper mapper)
        {
            this._services = services;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceResponse>> Get()
        {
            try
            {
                return _mapper.Map<IEnumerable<ServiceResponse>>(await _services.GetAllAsync());
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        public async Task<ServiceResponse> Post(ServiceRequest serviceRequest)
        {
            try
            {
                var service = _mapper.Map<Service>(serviceRequest);
                return _mapper.Map<ServiceResponse>(await _services.CreateAsync(service));
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public async Task<IEnumerable<ServiceResponse>> Put(IEnumerable<ServiceRequest> serviceRequests)
        {
            try
            {
                var services = _mapper.Map<IEnumerable<Service>>(serviceRequests);
                return _mapper.Map<IEnumerable<ServiceResponse>>(await _services.UpdateAsync(services));
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
                return await _services.DeleteAsync(ids);
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}