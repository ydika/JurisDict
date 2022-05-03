using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using JurisDict.Wpf.Services;
using JurisDict.Wpf.ViewModels;
using JurisDict.Wpf.Views;
using Microsoft.Extensions.Configuration;
using System.IO;
using JurisDict.Wpf.Dialogs.Interfaces;
using JurisDict.Wpf.Dialogs;
using JurisDict.Wpf.Views.Dialogs.UpdateDialogs;
using JurisDict.Wpf.Views.Dialogs.CreationDialogs;
using JurisDict.Wpf.ViewModels.CreateReadViewModels;
using JurisDict.Wpf.ViewModels.UpdateDeleteViewModels;

namespace JurisDict.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; }
        public IConfiguration Configuration { get; }

        public App()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            IDialogService dialogService = new DialogService(MainWindow);
            dialogService.Register<ClientViewModel, ClientUpdateDialog>();
            dialogService.Register<ContractServiceViewModel, ContractServiceUpdateDialog>();
            dialogService.Register<ContractViewModel, ContractUpdateDialog>();
            dialogService.Register<DepartmentViewModel, DepartmentUpdateDialog>();
            dialogService.Register<EmployeeViewModel, EmployeeUpdateDialog>();
            dialogService.Register<PositionViewModel, PositionUpdateDialog>();
            dialogService.Register<ServiceViewModel, ServiceUpdateDialog>();

            dialogService.Register<ClientsViewModel, ClientCreationDialog>();
            dialogService.Register<ContractServicesViewModel, ContractServiceCreationDialog>();
            dialogService.Register<ContractsViewModel, ContractCreationDialog>();
            dialogService.Register<DepartmentsViewModel, DepartmentCreationDialog>();
            dialogService.Register<EmployeesViewModel, EmployeeCreationDialog>();
            dialogService.Register<PositionsViewModel, PositionCreationDialog>();
            dialogService.Register<ServicesViewModel, ServiceCreationDialog>();

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(Configuration);
            ServiceConfigurator serviceConfigurator = new ServiceConfigurator();
            serviceConfigurator.ConfigureServices(services);
            services.AddSingleton(dialogService);
            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new MainWindow();
            MainWindow.DataContext = ServiceProvider.GetRequiredService<MainViewModel>();
            MainWindow.Show();
        }
    }
}
