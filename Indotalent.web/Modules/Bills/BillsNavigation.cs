using Serenity.Navigation;
using MyPages = Indotalent.Bills.Pages;

[assembly: NavigationMenu(5901, "Bills", icon: "fa-dollar")]
[assembly: NavigationLink(int.MaxValue, "Bills/Purchase Bill", typeof(MyPages.BillController), icon: "fa-folder")]
//[assembly: NavigationLink(int.MaxValue, "Bills/Bill Detail", typeof(MyPages.BillDetailController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "Bills/Bill Booked Reciept", typeof(MyPages.BillPaymentController), icon: "fa-folder")]