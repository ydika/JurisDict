using JurisDict.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace JurisDict.Api.Extensions
{
    public static class MvcOptionsExtension
    {
        public static void UseApiPrefix(this MvcOptions options, string prefixTemplate)
        {
            var attributeRouteModel = new AttributeRouteModel(new RouteAttribute(prefixTemplate));
            options.Conventions.Add(new PrefixConvention(attributeRouteModel));
        }
    }
}
