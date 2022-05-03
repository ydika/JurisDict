using AutoMapper;
using Common;
using Common.DTOs;
using Common.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JurisDict.Wpf.API;
using JurisDict.Wpf.Services.Interfaces;
using JurisDict.Wpf.Services;
using JurisDict.Wpf.ViewModels;
using Refit;
using JurisDict.Wpf.Handlers;
using JurisDict.Wpf.Dialogs.Interfaces;
using JurisDict.Wpf.Views.Dialogs;
using JurisDict.Wpf.Dialogs;
using System.Windows;
using JurisDict.Wpf.Views;
using JurisDict.Wpf.ViewModels.CreateReadViewModels;

namespace JurisDict.Wpf.Services
{
    public class ServiceConfigurator
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<ClientsViewModel>();
            services.AddSingleton<ContractServicesViewModel>();
            services.AddSingleton<ContractsViewModel>();
            services.AddSingleton<DepartmentsViewModel>();
            services.AddSingleton<EmployeesViewModel>();
            services.AddSingleton<PositionsViewModel>();
            services.AddSingleton<ServicesViewModel>();

            services.AddSingleton<INavigation, NavigationService>();

            services.AddSingleton<ApiSettings>();
            services.AddSingleton<IClientsProvider, ClientsService>();
            services.AddSingleton<IContractServicesProvider, ContractServsService>();
            services.AddSingleton<IContractsProvider, ContractsService>();
            services.AddSingleton<IDepartmentsProvider, DepartmentsService>();
            services.AddSingleton<IEmployeesProvider, EmployeesService>();
            services.AddSingleton<IPositionsProvider, PositionsService>();
            services.AddSingleton<IServicesProvider, ServsService>();

            MapperConfigurationExpression mapperConfigurationExpression = MapperConfigurationBuilder.Build();
            services.AddSingleton(mapperConfigurationExpression);
            services.AddSingleton<IConfigurationProvider, MapperConfiguration>();
            services.AddSingleton<Mapper>();

            var refitSettings = new RefitSettings()
            {
                HttpMessageHandlerFactory = () => new JurisDictClientHandler()
            };
            services.AddSingleton(refitSettings);

            services.AddSingleton<INavigationButtonBuilder, NavigationButtonBuilder>();
            services.AddSingleton<DeleteCommandProxy>();
            services.AddSingleton<UpdateCommandProxy>();
        }
    }
}
