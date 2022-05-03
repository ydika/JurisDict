using Common.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JurisDict.Wpf.API;
using JurisDict.Wpf.Services.Interfaces;
using Common.DTOs.Responses.CreateUpdateResponses;

namespace JurisDict.Wpf.Services
{
    public class ContractsService : IContractsProvider
    {
        private readonly IContractApi _contract;

        public ContractsService(ApiSettings apiSettings)
        {
            _contract = RestService.For<IContractApi>(apiSettings.Host, apiSettings.RefitSettings);
        }

        public async Task<ContractResponse> Create(Contract contract)
        {
            return await _contract.AddContract(contract).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ContractResponse>> Read()
        {
            return await _contract.GetContracts().ConfigureAwait(false);
        }

        public async Task<IEnumerable<ContractResponse>> Update(IEnumerable<Contract> models)
        {
            return await _contract.UpdateContracts(models).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Guid>> Delete(IEnumerable<Guid> ids)
        {
            return await _contract.DeleteContracts(ids).ConfigureAwait(false);
        }

        public async Task<ContractRelatedTablesResponse> ReadRelatedTables()
        {
            return await _contract.GetContractRelatedTables().ConfigureAwait(false);
        }
    }
}
