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
    public class PositionsService : IPositionsProvider
    {
        private readonly IPositionApi _position;

        public PositionsService(ApiSettings apiSettings)
        {
            _position = RestService.For<IPositionApi>(apiSettings.Host, apiSettings.RefitSettings);
        }

        public async Task<PositionResponse> Create(Position position)
        {
            return await _position.AddPosition(position).ConfigureAwait(false);
        }

        public async Task<IEnumerable<PositionResponse>> Read()
        {
            return await _position.GetPositions().ConfigureAwait(false);
        }

        public async Task<IEnumerable<PositionResponse>> Update(IEnumerable<Position> models)
        {
            return await _position.UpdatePositions(models).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Guid>> Delete(IEnumerable<Guid> ids)
        {
            return await _position.DeletePositions(ids).ConfigureAwait(false);
        }

        public Task<PositionResponse> ReadRelatedTables()
        {
            throw new NotImplementedException();
        }
    }
}
