using Common.DTOs;
using Common.DTOs.Responses.CreateUpdateResponses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisDict.Wpf.API
{
    public interface IContractServiceApi
    {
        [Get("/api/contractservices/")]
        Task<IEnumerable<ContractServiceResponse>> GetContractServices();
        [Get("/api/contractservices/getrelatedtables")]
        Task<ContractServiceRelatedTablesResponse> GetContractServiceRelatedTables();
        [Post("/api/contractServices/")]
        Task<ContractServiceResponse> AddContractService(ContractService contractService);
        [Put("/api/contractServices/")]
        Task<IEnumerable<ContractServiceResponse>> UpdateContractServices(IEnumerable<ContractService> contractServices);
        [Delete("/api/contractServices/")]
        Task<IEnumerable<Guid>> DeleteContractServices([Body]IEnumerable<Guid> ids);
    }
}
