using Common.Models.Base;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JurisDict.Api.Repositories.Interfaces
{
    public interface IRepository<TDbModel> where TDbModel : BaseModel
    {
        Task<IEnumerable<TDbModel>> GetAllAsync();
        Task<TDbModel> GetAsync(Guid id);
        Task<IEnumerable<TDbModel>> GetWithInclude(params Expression<Func<TDbModel, object>>[] includeProperties);
        Task<TDbModel> CreateAsync(TDbModel model);
        Task<IEnumerable<TDbModel>> UpdateAsync(IEnumerable<TDbModel> models);
        Task<IEnumerable<Guid>> DeleteAsync(IEnumerable<Guid> ids);
    }
}