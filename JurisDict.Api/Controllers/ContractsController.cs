using JurisDict.Api.Repositories.Interfaces;
using AutoMapper;
using Common.DTOs;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Common.Exceptions;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Common.Defaults;
using Common.DTOs.Responses.CreateUpdateResponses;
using static Common.DTOs.Responses.CreateUpdateResponses.RelatedTables;

namespace JurisDict.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly IRepository<Contract> _contracts;

        private readonly IRepository<Client> _clients;

        private readonly Mapper _mapper;

        public ContractsController(IRepository<Contract> contracts, IRepository<Client> clients, Mapper mapper)
        {
            this._contracts = contracts;
            this._clients = clients;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContractResponse>> Get()
        {
            try
            {
                return _mapper.Map<IEnumerable<ContractResponse>>(await _contracts.GetWithInclude(x => x.Client));
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ContractRelatedTablesResponse> GetRelatedTables()
        {
            try
            {
                ContractRelatedTablesResponse response = new()
                {
                    Contracts = _mapper.Map<IEnumerable<ContractResponse>>(await _contracts.GetAllAsync()),
                    Clients = _mapper.Map<IEnumerable<ClientRelatedTableResponse>>(await _clients.GetAllAsync())
                };
                return response;
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        public async Task<ContractResponse> Post(ContractRequest contractRequest)
        {
            try
            {
                var contract = _mapper.Map<Contract>(contractRequest);
                contract.Client = await _clients.GetAsync(contract.ClientId);
                return _mapper.Map<ContractResponse>(await _contracts.CreateAsync(contract));
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public async Task<IEnumerable<ContractResponse>> Put(IEnumerable<ContractRequest> contractRequests)
        {
            try
            {
                var contracts = _mapper.Map<IEnumerable<Contract>>(contractRequests);
                return _mapper.Map<IEnumerable<ContractResponse>>(await _contracts.UpdateAsync(contracts));
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
                return await _contracts.DeleteAsync(ids);
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}