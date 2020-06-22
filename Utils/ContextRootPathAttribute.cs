using Microsoft.AspNetCore.Mvc.Routing;
using System;

namespace DotNetAssignment.Utils
{
    public class ContextRootPathAttribute : Attribute, IRouteTemplateProvider
    {
        public string Name { get; set;}

        public int? Order => 2;

        public string Template => "api/";
    }
}