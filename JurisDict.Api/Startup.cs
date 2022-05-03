using JurisDict.Api.DataBase;
using JurisDict.Api.Extensions;
using JurisDict.Api.Repositories;
using JurisDict.Api.Repositories.Interfaces;
using AutoMapper;
using Common;
using Common.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace JurisDict.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configureservices(IServiceCollection services) 
        {
            services.AddControllers();
            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddMvc(o => 
                {
                    o.EnableEndpointRouting = false;
                    o.UseApiPrefix("api/");
                })
                .AddJsonOptions(options => options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic));
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection));

            services.AddTransient<IRepository<Client>, Repository<Client>>();
            services.AddTransient<IRepository<Contract>, Repository<Contract>>();
            services.AddTransient<IRepository<ContractService>, Repository<ContractService>>();
            services.AddTransient<IRepository<Department>, Repository<Department>>();
            services.AddTransient<IRepository<Employee>, Repository<Employee>>();
            services.AddTransient<IRepository<Position>, Repository<Position>>();
            services.AddTransient<IRepository<Service>, Repository<Service>>();

            MapperConfigurationExpression mapperConfigurationExpression = MapperConfigurationBuilder.Build();
            services.AddSingleton(mapperConfigurationExpression);
            services.AddSingleton<AutoMapper.IConfigurationProvider, MapperConfiguration>();
            services.AddSingleton<Mapper>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseHttpExceptions();

            app.UseAuthorization();

            app.UseMvc();
        }
    }
}
