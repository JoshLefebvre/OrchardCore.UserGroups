using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace OrchardCore.UserGroup
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageUserGroups = new Permission("ManageUserGroups");

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult(new[] { ManageUserGroups }.AsEnumerable());
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { ManageUserGroups }
                }
            };
        }
    }
}
