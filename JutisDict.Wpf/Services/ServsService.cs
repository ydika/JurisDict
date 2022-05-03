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
    public class ServsService : IServicesProvider
    {
        private readonly IServiceApi _service;

        public ServsService(ApiSettings apiSettings)
        {
            _service = RestService.For<IServiceApi>(apiSettings.Host, apiSettings.RefitSettings);
        }

        public async Task<ServiceResponse> Create(Service service)
        {
            return await _service.AddService(service).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ServiceResponse>> Read()
        {
            return await _service.GetServices().ConfigureAwait(false);
        }

        public async Task<IEnumerable<ServiceResponse>> Update(IEnumerable<Service> models)
        {
            return await _service.UpdateServices(models).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Guid>> Delete(IEnumerable<Guid> ids)
        {
            return await _service.DeleteServices(ids).ConfigureAwait(false);
        }

        public Task<ServiceResponse> ReadRelatedTables()
        {
            throw new NotImplementedException();
        }
    }
}
