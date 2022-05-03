using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisDict.Wpf.Services.Interfaces
{
    public interface ICrudProvider<TResponse, TModel>
    {
        Task<TResponse> Create(TModel models);
        Task<IEnumerable<TResponse>> Read();
        Task<IEnumerable<TResponse>> Update(IEnumerable<TModel> models);
        Task<IEnumerable<Guid>> Delete(IEnumerable<Guid> ids);
    }
}
