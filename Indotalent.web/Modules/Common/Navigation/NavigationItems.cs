using Serenity.Navigation;
using Administration = Indotalent.Administration.Pages;

[assembly: NavigationMenu(1000, "Dashboard", icon: "fa-tachometer")]
[assembly: NavigationLink(1001, "Dashboard/Inventory", url: "~/Dashboard/Inventory", permission: "Dashboard:Inventory", icon: "fa-folder")]
[assembly: NavigationLink(1002, "Dashboard/Invoice", url: "~/Dashboard/Invoice", permission: "Dashboard:Invoice", icon: "fa-folder")]
[assembly: NavigationLink(1003, "Dashboard/Project", url: "~/Dashboard/Project", permission: "Dashboard:Project", icon: "fa-folder")]

