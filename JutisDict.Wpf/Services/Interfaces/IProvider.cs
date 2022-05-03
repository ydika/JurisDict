using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisDict.Wpf.Services.Interfaces
{
    public interface IProvider<TRelatedTablesResponse, TResponse, TModel> : ICrudProvider<TResponse, TModel>
    {
        Task<TRelatedTablesResponse> ReadRelatedTables();
    }
}
