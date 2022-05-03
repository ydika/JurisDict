using AutoMapper;
using Common.Defaults;
using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.DTOs.Responses.CreateUpdateResponses.RelatedTables;

namespace Common
{
    public class MapperConfigurationBuilder
    {
        public static MapperConfigurationExpression Build()
        {
            MapperConfigurationExpression mapperConfigurationExpression = new MapperConfigurationExpression();

            mapperConfigurationExpression.CreateMap<Client, ClientResponse>().ReverseMap();
            mapperConfigurationExpression.CreateMap<Contract, ContractResponse>().ReverseMap();
            mapperConfigurationExpression.CreateMap<ContractService, ContractServiceResponse>().ReverseMap();
            mapperConfigurationExpression.CreateMap<Department, DepartmentResponse>().ReverseMap();
            mapperConfigurationExpression.CreateMap<Employee, EmployeeResponse>().ReverseMap();
            mapperConfigurationExpression.CreateMap<Position, PositionResponse>().ReverseMap();
            mapperConfigurationExpression.CreateMap<Service, ServiceResponse>().ReverseMap();

            mapperConfigurationExpression.CreateMap<Client, ClientRequest>().ReverseMap();
            mapperConfigurationExpression.CreateMap<Contract, ContractRequest>().ReverseMap();
            mapperConfigurationExpression.CreateMap<ContractService, ContractServiceRequest>().ReverseMap();
            mapperConfigurationExpression.CreateMap<Department, DepartmentRequest>().ReverseMap();
            mapperConfigurationExpression.CreateMap<Employee, EmployeeRequest>().ReverseMap();
            mapperConfigurationExpression.CreateMap<Position, PositionRequest>().ReverseMap();
            mapperConfigurationExpression.CreateMap<Service, ServiceRequest>().ReverseMap();

            mapperConfigurationExpression.CreateMap<Client, ClientRelatedTableResponse>().ReverseMap();
            mapperConfigurationExpression.CreateMap<Contract, ContractRelatedTableResponse>().ReverseMap();
            mapperConfigurationExpression.CreateMap<Department, DepartmentRelatedTableResponse>().ReverseMap();
            mapperConfigurationExpression.CreateMap<Employee, EmployeeRelatedTableResponse>().ReverseMap();
            mapperConfigurationExpression.CreateMap<Position, PositionRelatedTableResponse>().ReverseMap();
            mapperConfigurationExpression.CreateMap<Service, ServiceRelatedTableResponse>().ReverseMap();

            return mapperConfigurationExpression;
        }
    }
}
