using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.UserGroup.Models;

namespace OrchardCore.UserGroup.ViewModels
{
    public class UserGroupListPartEditViewModel
    {
        public List<GroupUserEditViewModel> SelectedUsers { get; set; }  = new List<GroupUserEditViewModel>();

    }

    public class GroupUserEditViewModel
    {
        public GroupUser GroupUser { get; set; }
        public bool IsInGroup { get; set; }
    }
}
