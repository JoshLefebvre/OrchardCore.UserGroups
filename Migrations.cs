using System;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace OrchardCore.UserGroup
{
    public class Migrations : DataMigration
    {
        IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition("UserGroupListPart", builder => builder
                .Attachable()
                .WithDescription("UserGroupListPart for fields related to user groups")
            );
            
            _contentDefinitionManager.AlterTypeDefinition("UserGroup", builder => builder
                .Listable()
                .WithPart("TitlePart", part => part.WithPosition("1"))
                .WithPart("UserGroupPart", part => part.WithPosition("2"))
                .WithPart("UserGroupListPart", part => part.WithPosition("3"))            
            );

            return 1;
        }
    }
}
