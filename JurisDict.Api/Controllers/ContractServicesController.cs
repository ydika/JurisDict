using JurisDict.Api.Repositories.Interfaces;
using AutoMapper;
using Common.DTOs;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Common.Exceptions;
using System.Net;
using Common.Defaults;
using Common.DTOs.Responses.CreateUpdateResponses;
using static Common.DTOs.Responses.CreateUpdateResponses.RelatedTables;

namespace JurisDict.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractServicesController : ControllerBase
    {
        private readonly IRepository<ContractService> _contractServices;

        private readonly IRepository<Contract> _contracts;
        private readonly IRepository<Service> _services;
        private readonly IRepository<Employee> _employees;

        private readonly Mapper _mapper;

        public ContractServicesController(IRepository<ContractService> contractServices, IRepository<Contract> contracts, 
            IRepository<Service> services, IRepository<Employee> employees, Mapper mapper)
        {
            this._contractServices = contractServices;
            this._contracts = contracts;
            this._services = services;
            this._employees = employees;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContractServiceResponse>> Get()
        {
            try
            {
                return _mapper.Map<IEnumerable<ContractServiceResponse>>(await _contractServices.GetWithInclude(x => x.Contract, x => x.Service, x => x.Employee));
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ContractServiceRelatedTablesResponse> GetRelatedTables()
        {
            try
            {
                ContractServiceRelatedTablesResponse response = new()
                {
                    ContractServices = _mapper.Map<IEnumerable<ContractServiceResponse>>(await _contractServices.GetAllAsync()),
                    Contracts = _mapper.Map<IEnumerable<ContractRelatedTableResponse>>(await _contracts.GetAllAsync()),
                    Services = _mapper.Map<IEnumerable<ServiceRelatedTableResponse>>(await _services.GetAllAsync()),
                    Employees = _mapper.Map<IEnumerable<EmployeeRelatedTableResponse>>(await _employees.GetAllAsync())
                };
                return response;
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        public async Task<ContractServiceResponse> Post(ContractServiceRequest contractServiceRequest)
        {
            try
            {
                var contractService = _mapper.Map<ContractService>(contractServiceRequest);
                contractService.Contract = await _contracts.GetAsync(contractService.ContractId);
                contractService.Service = await _services.GetAsync(contractService.ServiceId);
                contractService.Employee = await _employees.GetAsync(contractService.EmployeeId);
                return _mapper.Map<ContractServiceResponse>(await _contractServices.CreateAsync(contractService));
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public async Task<IEnumerable<ContractServiceResponse>> Put(IEnumerable<ContractServiceRequest> contractServiceRequests)
        {
            try
            {
                var contractService = _mapper.Map<IEnumerable<ContractService>>(contractServiceRequests);
                return _mapper.Map<IEnumerable<ContractServiceResponse>>(await _contractServices.UpdateAsync(contractService));
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
                return await _contractServices.DeleteAsync(ids);
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}