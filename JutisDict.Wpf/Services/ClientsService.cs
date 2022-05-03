using Common.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JurisDict.Wpf.API;
using JurisDict.Wpf.Services.Interfaces;
using Common.Models;

namespace JurisDict.Wpf.Services
{
    public class ClientsService : IClientsProvider
    {
        private readonly IClientApi _client;

        public ClientsService(ApiSettings apiSettings)
        {
            _client = RestService.For<IClientApi>(apiSettings.Host, apiSettings.RefitSettings);
        }

        public async Task<ClientResponse> Create(Client client)
        {
            return await _client.AddClient(client).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ClientResponse>> Read()
        {
            return await _client.GetClients().ConfigureAwait(false);
        }

        public async Task<IEnumerable<ClientResponse>> Update(IEnumerable<Client> models)
        {
            return await _client.UpdateClients(models).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Guid>> Delete(IEnumerable<Guid> ids)
        {
            return await _client.DeleteClients(ids).ConfigureAwait(false);
        }

        public Task<ClientResponse> ReadRelatedTables()
        {
            throw new NotImplementedException();
        }
    }
}
