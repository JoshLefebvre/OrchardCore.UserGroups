using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Newtonsoft.Json.Linq;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Notify;
using OrchardCore.UserGroup.Models;
using YesSql;

namespace OrchardCore.UserGroup.Controllers
{
    public class AdminController : Controller
    {
        // private readonly IContentManager _contentManager;
        // private readonly IAuthorizationService _authorizationService;
        // private readonly IContentItemDisplayManager _contentItemDisplayManager;
        // private readonly IContentDefinitionManager _contentDefinitionManager;
        // private readonly ISession _session;
        // private readonly INotifier _notifier;
        // private readonly IHtmlLocalizer H;
        // private readonly IUpdateModelAccessor _updateModelAccessor;

        // public AdminController(
        //     ISession session,
        //     IContentManager contentManager,
        //     IAuthorizationService authorizationService,
        //     IContentItemDisplayManager contentItemDisplayManager,
        //     IContentDefinitionManager contentDefinitionManager,
        //     INotifier notifier,
        //     IHtmlLocalizer<AdminController> localizer,
        //     IUpdateModelAccessor updateModelAccessor)
        // {
        //     _contentManager = contentManager;
        //     _authorizationService = authorizationService;
        //     _contentItemDisplayManager = contentItemDisplayManager;
        //     _contentDefinitionManager = contentDefinitionManager;
        //     _session = session;
        //     _notifier = notifier;
        //     _updateModelAccessor = updateModelAccessor;
        //     H = localizer;
        // }

        // public async Task<IActionResult> Create(string id, string menuContentItemId, string menuItemId)
        // {
        //     if (String.IsNullOrWhiteSpace(id))
        //     {
        //         return NotFound();
        //     }

        //     if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageUserGroup))
        //     {
        //         return Forbid();
        //     }

        //     var contentItem = await _contentManager.NewAsync(id);

        //     dynamic model = await _contentItemDisplayManager.BuildEditorAsync(contentItem, _updateModelAccessor.ModelUpdater, true);

        //     model.UserGroupContentItemId = menuContentItemId;
        //     model.UserGroupItemId = menuItemId;

        //     return View(model);
        // }

        // [HttpPost]
        // [ActionName("Create")]
        // public async Task<IActionResult> CreatePost(string id, string menuContentItemId, string menuItemId)
        // {
        //     if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageUserGroup))
        //     {
        //         return Forbid();
        //     }

        //     ContentItem menu;

        //     var contentTypeDefinition = _contentDefinitionManager.GetTypeDefinition("UserGroup");

        //     if (!contentTypeDefinition.GetSettings<ContentTypeSettings>().Draftable)
        //     {
        //         menu = await _contentManager.GetAsync(menuContentItemId, VersionOptions.Latest);
        //     }
        //     else
        //     {
        //         menu = await _contentManager.GetAsync(menuContentItemId, VersionOptions.DraftRequired);
        //     }

        //     if (menu == null)
        //     {
        //         return NotFound();
        //     }

        //     var contentItem = await _contentManager.NewAsync(id);

        //     var model = await _contentItemDisplayManager.UpdateEditorAsync(contentItem, _updateModelAccessor.ModelUpdater, true);

        //     if (!ModelState.IsValid)
        //     {
        //         return View(model);
        //     }

        //     if (menuItemId == null)
        //     {
        //         // Use the menu as the parent if no target is specified
        //         menu.Alter<UserGroupItemsListPart>(part => part.UserGroupItems.Add(contentItem));
        //     }
        //     else
        //     {
        //         // Look for the target menu item in the hierarchy
        //         var parentUserGroupItem = FindUserGroupItem(menu.Content, menuItemId);

        //         // Couldn't find targeted menu item
        //         if (parentUserGroupItem == null)
        //         {
        //             return NotFound();
        //         }

        //         var menuItems = parentUserGroupItem?.UserGroupItemsListPart?.UserGroupItems as JArray;

        //         if (menuItems == null)
        //         {
        //             parentUserGroupItem["UserGroupItemsListPart"] = new JObject(
        //                 new JProperty("UserGroupItems", menuItems = new JArray())
        //                 );
        //         }

        //         menuItems.Add(JObject.FromObject(contentItem));
        //     }

        //     _session.Save(menu);

        //     return RedirectToAction("Edit", "Admin", new { area = "OrchardCore.Contents", contentItemId = menuContentItemId });
        // }

        // public async Task<IActionResult> Edit(string menuContentItemId, string menuItemId)
        // {
        //     var menu = await _contentManager.GetAsync(menuContentItemId, VersionOptions.Latest);

        //     if (menu == null)
        //     {
        //         return NotFound();
        //     }

        //     if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageUserGroup, menu))
        //     {
        //         return Forbid();
        //     }

        //     // Look for the target menu item in the hierarchy
        //     JObject menuItem = FindUserGroupItem(menu.Content, menuItemId);

        //     // Couldn't find targetted menu item
        //     if (menuItem == null)
        //     {
        //         return NotFound();
        //     }

        //     var contentItem = menuItem.ToObject<ContentItem>();

        //     dynamic model = await _contentItemDisplayManager.BuildEditorAsync(contentItem, _updateModelAccessor.ModelUpdater, false);

        //     model.UserGroupContentItemId = menuContentItemId;
        //     model.UserGroupItemId = menuItemId;

        //     return View(model);
        // }

        // [HttpPost]
        // [ActionName("Edit")]
        // public async Task<IActionResult> EditPost(string menuContentItemId, string menuItemId)
        // {
        //     if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageUserGroup))
        //     {
        //         return Forbid();
        //     }

        //     ContentItem menu;

        //     var contentTypeDefinition = _contentDefinitionManager.GetTypeDefinition("UserGroup");

        //     if (!contentTypeDefinition.GetSettings<ContentTypeSettings>().Draftable)
        //     {
        //         menu = await _contentManager.GetAsync(menuContentItemId, VersionOptions.Latest);
        //     }
        //     else
        //     {
        //         menu = await _contentManager.GetAsync(menuContentItemId, VersionOptions.DraftRequired);
        //     }

        //     if (menu == null)
        //     {
        //         return NotFound();
        //     }

        //     // Look for the target menu item in the hierarchy
        //     JObject menuItem = FindUserGroupItem(menu.Content, menuItemId);

        //     // Couldn't find targetted menu item
        //     if (menuItem == null)
        //     {
        //         return NotFound();
        //     }

        //     var contentItem = menuItem.ToObject<ContentItem>();

        //     var model = await _contentItemDisplayManager.UpdateEditorAsync(contentItem, _updateModelAccessor.ModelUpdater, false);

        //     if (!ModelState.IsValid)
        //     {
        //         return View(model);
        //     }

        //     menuItem.Merge(contentItem.Content, new JsonMergeSettings
        //     {
        //         MergeArrayHandling = MergeArrayHandling.Replace,
        //         MergeNullValueHandling = MergeNullValueHandling.Merge
        //     });

        //     _session.Save(menu);

        //     return RedirectToAction("Edit", "Admin", new { area = "OrchardCore.Contents", contentItemId = menuContentItemId });
        // }

        // [HttpPost]
        // public async Task<IActionResult> Delete(string menuContentItemId, string menuItemId)
        // {
        //     if (!await _authorizationService.AuthorizeAsync(User, Permissions.ManageUserGroup))
        //     {
        //         return Forbid();
        //     }

        //     ContentItem menu;

        //     var contentTypeDefinition = _contentDefinitionManager.GetTypeDefinition("UserGroup");

        //     if (!contentTypeDefinition.GetSettings<ContentTypeSettings>().Draftable)
        //     {
        //         menu = await _contentManager.GetAsync(menuContentItemId, VersionOptions.Latest);
        //     }
        //     else
        //     {
        //         menu = await _contentManager.GetAsync(menuContentItemId, VersionOptions.DraftRequired);
        //     }

        //     if (menu == null)
        //     {
        //         return NotFound();
        //     }

        //     // Look for the target menu item in the hierarchy
        //     var menuItem = FindUserGroupItem(menu.Content, menuItemId);

        //     // Couldn't find targetted menu item
        //     if (menuItem == null)
        //     {
        //         return NotFound();
        //     }

        //     menuItem.Remove();
        //     _session.Save(menu);

        //     _notifier.Success(H["UserGroup item deleted successfully"]);

        //     return RedirectToAction("Edit", "Admin", new { area = "OrchardCore.Contents", contentItemId = menuContentItemId });
        // }

        // private JObject FindUserGroupItem(JObject contentItem, string menuItemId)
        // {
        //     if (contentItem["ContentItemId"]?.Value<string>() == menuItemId)
        //     {
        //         return contentItem;
        //     }

        //     if (contentItem.GetValue("UserGroupItemsListPart") == null)
        //     {
        //         return null;
        //     }

        //     var menuItems = (JArray)contentItem["UserGroupItemsListPart"]["UserGroupItems"];

        //     JObject result;

        //     foreach (JObject menuItem in menuItems)
        //     {
        //         // Search in inner menu items
        //         result = FindUserGroupItem(menuItem, menuItemId);

        //         if (result != null)
        //         {
        //             return result;
        //         }
        //     }

        //     return null;
        // }
    }
}
