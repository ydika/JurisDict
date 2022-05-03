using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace JurisDict.Api.Services
{
    public class PrefixConvention : IControllerModelConvention
    {
        private readonly AttributeRouteModel _prefixTemplate;

        public PrefixConvention(AttributeRouteModel prefixTemplate)
        {
            this._prefixTemplate = prefixTemplate;
        }

        public void Apply(ControllerModel controller)
        {
            var selectors = controller.Selectors;
            if (selectors.Any())
            {
                foreach (var selector in selectors)
                {
                    if (selector.AttributeRouteModel is not null)
                    {
                        selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_prefixTemplate, selector.AttributeRouteModel);
                    }
                    else
                    {
                        selector.AttributeRouteModel = _prefixTemplate;
                    }
                }
            }
        }
    }
}
