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
    public interface IContractApi
    {
        [Get("/api/contracts/")]
        Task<IEnumerable<ContractResponse>> GetContracts();
        [Get("/api/contracts/getrelatedtables")]
        Task<ContractRelatedTablesResponse> GetContractRelatedTables();
        [Post("/api/contracts/")]
        Task<ContractResponse> AddContract(Contract contract);
        [Put("/api/contracts/")]
        Task<IEnumerable<ContractResponse>> UpdateContracts(IEnumerable<Contract> contracts);
        [Delete("/api/contracts/")]
        Task<IEnumerable<Guid>> DeleteContracts([Body]IEnumerable<Guid> ids);
    }
}
