using Serenity.Navigation;
using MyPages = Indotalent.Material.Pages;

[assembly: NavigationMenu(5900, "Material", icon: "fa-list-alt")]
[assembly: NavigationLink(5900, "Material/Status Master", typeof(MyPages.StatusMasterController), icon: "fa-folder")]
[assembly: NavigationLink(3900, "Material/Material Request", typeof(MyPages.RequestController), icon: "fa-folder")]

[assembly: NavigationLink(4900, "Material/Material Issue", typeof(MyPages.IssueController), icon: "fa-folder")]
//[assembly: NavigationLink(int.MaxValue, "Material_Request/Material Request Traciking", typeof(MyPages.MaterialRequestTrackingController), icon: "fa-folder")]
[assembly: NavigationLink(3800, "Material/Material Request Summary", url: "~/Material/MaterialOverview", permission: "Material:MaterialOverview", icon: "fa-folder")]
