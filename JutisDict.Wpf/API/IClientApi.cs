using Common.DTOs;
using Common.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisDict.Wpf.API
{
    public interface IClientApi
    {
        [Get("/api/clients/")]
        Task<IEnumerable<ClientResponse>> GetClients();
        [Post("/api/clients/")]
        Task<ClientResponse> AddClient(Client client);
        [Put("/api/clients/")]
        Task<IEnumerable<ClientResponse>> UpdateClients(IEnumerable<Client> clients);
        [Delete("/api/clients/")]
        Task<IEnumerable<Guid>> DeleteClients([Body]IEnumerable<Guid> ids);
    }
}
