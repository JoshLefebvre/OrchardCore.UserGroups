using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Admin;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.Data.Migration;
using OrchardCore.DisplayManagement.Descriptors;
using OrchardCore.UserGroup.Controllers;
using OrchardCore.UserGroup.Drivers;
using OrchardCore.UserGroup.Models;
using OrchardCore.Modules;
using OrchardCore.Mvc.Core.Utilities;
using OrchardCore.Navigation;
using OrchardCore.Security.Permissions;

namespace OrchardCore.UserGroup
{
    public class Startup : StartupBase
    {
        private readonly AdminOptions _adminOptions;

        public Startup(IOptions<AdminOptions> adminOptions)
        {
            _adminOptions = adminOptions.Value;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataMigration, Migrations>();
            services.AddScoped<IPermissionProvider, Permissions>();
            services.AddScoped<INavigationProvider, AdminUserGroup>();

            // UserGroupPart;
            services.AddContentPart<UserGroupListPart>()
                .UseDisplayDriver<UserGroupListPartDisplayDriver>();

        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            var adminControllerName = typeof(AdminController).ControllerName();

            // routes.MapAreaControllerRoute(
            //     name: "UserGroupCreate",
            //     areaName: "OrchardCore.UserGroup",
            //     pattern: _adminOptions.AdminUrlPrefix + "/UserGroup/Create/{id}",
            //     defaults: new { controller = adminControllerName, action = nameof(AdminController.Create) }
            // );
            // routes.MapAreaControllerRoute(
            //     name: "UserGroupDelete",
            //     areaName: "OrchardCore.UserGroup",
            //     pattern: _adminOptions.AdminUrlPrefix + "/UserGroup/Delete",
            //     defaults: new { controller = adminControllerName, action = nameof(AdminController.Delete) }
            // );
            // routes.MapAreaControllerRoute(
            //     name: "UserGroupEdit",
            //     areaName: "OrchardCore.UserGroup",
            //     pattern: _adminOptions.AdminUrlPrefix + "/UserGroup/Edit",
            //     defaults: new { controller = adminControllerName, action = nameof(AdminController.Edit) }
            // );
        }
    }
}
