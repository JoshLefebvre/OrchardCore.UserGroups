using System.Collections.Generic;
using OrchardCore.ContentManagement;

namespace OrchardCore.UserGroup.Models
{
    public class UserGroupListPart : ContentPart
    {
        public List<GroupUser> UserGroupItems { get; set; } = new List<GroupUser>();
    }
}
