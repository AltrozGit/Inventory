using Microsoft.AspNetCore.Mvc.RazorPages;
using Serenity.Navigation;
using MyPages = Indotalent.Projects.Pages;
[assembly: NavigationMenu(4900, "Projects", icon: "fa-hdd-o")]
[assembly: NavigationLink(4900, "Projects/Project", typeof(MyPages.ProjectController), icon: "fa-folder")]
[assembly: NavigationLink(4900, "Projects/Project Expense", typeof(MyPages.ProjectExpenseController), icon: "fa-folder")]
[assembly: NavigationLink(4901, "Projects/Expense Type", typeof(MyPages.ExpenseController), icon: "fa-folder")]
[assembly: NavigationLink(4901, "Projects/Project Material Request", typeof(MyPages.ProjectMaterialRequestController), icon: "fa-folder")]
//[assembly: NavigationLink(4901, "Projects/Project Material Request Detail", typeof(MyPages.ProjectMaterialRequestDetailController), icon: "fa-folder")]


[assembly: NavigationLink(int.MaxValue, "Projects/Quotation", typeof(MyPages.QuotationController), icon: "fa-folder")]
//[assembly: NavigationLink(int.MaxValue, "Projects/Vw Project Fund", typeof(MyPages.VwProjectFundController), icon: null)]