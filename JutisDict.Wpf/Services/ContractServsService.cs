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
    public class ContractServsService : IContractServicesProvider
    {
        private readonly IContractServiceApi _contractService;

        public ContractServsService(ApiSettings apiSettings)
        {
            _contractService = RestService.For<IContractServiceApi>(apiSettings.Host, apiSettings.RefitSettings);
        }

        public async Task<ContractServiceResponse> Create(ContractService contractService)
        {
            return await _contractService.AddContractService(contractService).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ContractServiceResponse>> Read()
        {
            return await _contractService.GetContractServices().ConfigureAwait(false);
        }

        public async Task<IEnumerable<ContractServiceResponse>> Update(IEnumerable<ContractService> models)
        {
            return await _contractService.UpdateContractServices(models).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Guid>> Delete(IEnumerable<Guid> ids)
        {
            return await _contractService.DeleteContractServices(ids).ConfigureAwait(false);
        }

        public async Task<ContractServiceRelatedTablesResponse> ReadRelatedTables()
        {
            return await _contractService.GetContractServiceRelatedTables().ConfigureAwait(false);
        }
    }
}
