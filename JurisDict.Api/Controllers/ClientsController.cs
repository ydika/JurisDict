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
    public class ClientsController : ControllerBase
    {
        private readonly IRepository<Client> _clients;
        private readonly Mapper _mapper;

        public ClientsController(IRepository<Client> clients, Mapper mapper)
        {
            this._clients = clients;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClientResponse>> Get()
        {
            try
            {
                return _mapper.Map<IEnumerable<ClientResponse>>(await _clients.GetAllAsync());
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        public async Task<ClientResponse> Post(ClientRequest clientRequest)
        {
            try
            {
                var client = _mapper.Map<Client>(clientRequest);
                return _mapper.Map<ClientResponse>(await _clients.CreateAsync(client));
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public async Task<IEnumerable<ClientResponse>> Put(IEnumerable<ClientRequest> clientRequests)
        {
            try
            {
                var clients = _mapper.Map<IEnumerable<Client>>(clientRequests);
                return _mapper.Map<IEnumerable<ClientResponse>>(await _clients.UpdateAsync(clients));
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpDelete]
        public async Task<IEnumerable<Guid>> Delete(IEnumerable<Guid> ids)
        {
            try
            {
                return await _clients.DeleteAsync(ids);
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}