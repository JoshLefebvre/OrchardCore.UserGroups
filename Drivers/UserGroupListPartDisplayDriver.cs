using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.UserGroup.Models;
using OrchardCore.UserGroup.ViewModels;
using YesSql;
using OrchardCore.Users.Indexes;
using OrchardCore.Users.Models;
using OrchardCore.ContentManagement.Display.Models;

namespace OrchardCore.UserGroup.Drivers
{
    public class UserGroupListPartDisplayDriver : ContentPartDisplayDriver<UserGroupListPart>
    {
        private readonly IContentManager _contentManager;
        private readonly IServiceProvider _serviceProvider;
        private readonly IContentDefinitionManager _contentDefinitionManager;

        private readonly ISession _session;

        public UserGroupListPartDisplayDriver(
            IContentDefinitionManager contentDefinitionManager,
            IContentManager contentManager,
            IServiceProvider serviceProvider,
            ISession session
            )
        {
            _contentDefinitionManager = contentDefinitionManager;
            _serviceProvider = serviceProvider;
            _contentManager = contentManager;
            _session = session;
        }

        public override async Task<IDisplayResult> EditAsync(UserGroupListPart part, BuildPartEditorContext context)
        {
            var users = await _session.Query<User, UserIndex>().ListAsync();//User Service should have a function to get all users
            return Initialize<UserGroupListPartEditViewModel>("UserGroupListPart_Edit", model =>
            {
                foreach(var user in users)
                {
                    model.SelectedUsers.Add(
                        new GroupUserEditViewModel()
                        {
                            GroupUser = new GroupUser(){Username = user.UserName, Email = user.Email},
                            IsInGroup = false// todo
                        }
                    );

                }
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(UserGroupListPart part, IUpdateModel updater)
        {
            var model = new UserGroupListPartEditViewModel();

            if (await updater.TryUpdateModelAsync(model, Prefix, t=>t.SelectedUsers))
            {
                part.UserGroupItems = model.SelectedUsers.Select(x=>x.GroupUser).ToList();;
            }

            return Edit(part);
        }
    }
}
