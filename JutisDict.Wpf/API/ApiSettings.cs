using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisDict.Wpf.API
{
    public class ApiSettings
    {
        public string Host { get; }
        public RefitSettings RefitSettings { get; }

        public ApiSettings(IConfiguration configuration, RefitSettings refitSettings)
        {
            Host = configuration["host"];
            RefitSettings = refitSettings;
        }
    }
}
