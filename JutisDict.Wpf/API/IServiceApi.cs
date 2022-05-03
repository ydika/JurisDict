using Common.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisDict.Wpf.API
{
    public interface IServiceApi
    {
        [Get("/api/services/")]
        Task<IEnumerable<ServiceResponse>> GetServices();
        [Post("/api/services/")]
        Task<ServiceResponse> AddService(Service service);
        [Put("/api/services/")]
        Task<IEnumerable<ServiceResponse>> UpdateServices(IEnumerable<Service> services);
        [Delete("/api/services/")]
        Task<IEnumerable<Guid>> DeleteServices([Body]IEnumerable<Guid> ids);
    }
}
