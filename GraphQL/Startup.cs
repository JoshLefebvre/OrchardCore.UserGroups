using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Apis;
using OrchardCore.ContentManagement.GraphQL.Queries.Types;
using OrchardCore.UserGroup.Models;
using OrchardCore.Modules;

namespace OrchardCore.UserGroup.GraphQL
{
    [RequireFeatures("OrchardCore.Apis.GraphQL")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {

        }
    }
}
