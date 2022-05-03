using Common.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisDict.Wpf.API
{
    public interface IPositionApi
    {
        [Get("/api/positions/")]
        Task<IEnumerable<PositionResponse>> GetPositions();
        [Post("/api/positions/")]
        Task<PositionResponse> AddPosition(Position position);
        [Put("/api/positions/")]
        Task<IEnumerable<PositionResponse>> UpdatePositions(IEnumerable<Position> positions);
        [Delete("/api/positions/")]
        Task<IEnumerable<Guid>> DeletePositions([Body]IEnumerable<Guid> ids);
    }
}
