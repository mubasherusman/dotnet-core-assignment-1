using Microsoft.AspNetCore.Mvc.Routing;
using System;

namespace Assignment_1.Utils
{
    public class ContextRootPathAttribute : Attribute, IRouteTemplateProvider
    {
        public string Name { get; set;}

        public int? Order => 2;

        public string Template => "api/";
    }
}