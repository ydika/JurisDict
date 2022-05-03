using Common.DTOs;
using Common.DTOs.Responses.CreateUpdateResponses;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisDict.Wpf.Services.Interfaces
{
    public interface IContractsProvider : IProvider<ContractRelatedTablesResponse, ContractResponse, Contract>
    {
    }
}
