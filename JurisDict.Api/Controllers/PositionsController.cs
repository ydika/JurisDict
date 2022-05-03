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
    public class PositionsController : ControllerBase
    {
        private readonly IRepository<Position> _positions;
        private readonly Mapper _mapper;

        public PositionsController(IRepository<Position> positions, Mapper mapper)
        {
            this._positions = positions;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PositionResponse>> Get()
        {
            try
            {
                return _mapper.Map<IEnumerable<PositionResponse>>(await _positions.GetAllAsync());
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        public async Task<PositionResponse> Post(PositionRequest positionRequest)
        {
            try
            {
                var position = _mapper.Map<Position>(positionRequest);
                return _mapper.Map<PositionResponse>(await _positions.CreateAsync(position));
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut]
        public async Task<IEnumerable<PositionResponse>> Put(IEnumerable<PositionRequest> positionRequests)
        {
            try
            {
                var positions = _mapper.Map<IEnumerable<Position>>(positionRequests);
                return _mapper.Map<IEnumerable<PositionResponse>>(await _positions.UpdateAsync(positions));
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
                return await _positions.DeleteAsync(ids);
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}