using DocumentFormat.OpenXml.Drawing.Charts;
using Serenity.Navigation;
using MyPages = Indotalent.General.Pages;

[assembly: NavigationMenu(5900, "General", icon: "fa-list-alt")]
[assembly: NavigationLink(int.MaxValue, "General/Action", typeof(MyPages.ActionController), icon: "fa-clone")]
[assembly: NavigationLink(int.MaxValue, "General/Template", typeof(MyPages.TemplateController), icon: "fa-plus")]
[assembly: NavigationLink(int.MaxValue, "General/Action Notification", typeof(MyPages.ActionNotificationController), icon: null)]