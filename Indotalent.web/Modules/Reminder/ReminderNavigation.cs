using Serenity.Navigation;
using MyPages = Indotalent.Reminder.Pages;

[assembly: NavigationLink(int.MaxValue, "Notifications", typeof(MyPages.DueDateReminderController), icon: "fa-bell")]
[assembly: NavigationLink(int.MaxValue, "Notifications/Due Date Notifications", typeof(MyPages.DueDateReminderController), icon: "fa-bell")]
[assembly: NavigationLink(int.MaxValue, "Email Broadcast", typeof(MyPages.BulkEmailFileUploadController), icon: "fa-envelope")]

[assembly: NavigationLink(int.MaxValue, "Email Broadcast/Email Broadcast", typeof(MyPages.BulkEmailFileUploadController), icon: "fa-envelope")]
[assembly: NavigationLink(int.MaxValue, "Email Broadcast/Email Broadcast Status", typeof(MyPages.BulkEmailSenderStatusController), icon: "fa-folder")]

[assembly: NavigationLink(int.MaxValue, "Email Broadcast/Smtp Configuration", typeof(MyPages.SmtpConfigurationController), icon: "fa-server")]
[assembly: NavigationLink(1003, "Email Broadcast/Email Sending Summary", url: "~/Notifications/EmailSendingSummary", permission: "Notifications:EmailSendingSummary", icon: "fa-list-alt")]
[assembly: NavigationLink(int.MaxValue, "Subscriptions", typeof(MyPages.SubscriptionController), icon: "fa-folder")]

[assembly: NavigationLink(int.MaxValue, "Subscriptions/Plans", typeof(MyPages.PlanSettingController), icon: "fa-folder")]
[assembly: NavigationLink(int.MaxValue, "Subscriptions/Add Balance", typeof(MyPages.AddBalanceController), icon: "fa-dollar")]
[assembly: NavigationLink(int.MaxValue, "Subscriptions/Subscription", typeof(MyPages.SubscriptionController), icon: "fa-folder")]
[assembly: NavigationLink(int.MaxValue, "Subscriptions/Tenant Unit Transaction", typeof(MyPages.TenantUnitTransactionController), icon: "fa-exchange")]
//[assembly: NavigationLink(int.MaxValue, "Subscriptions/Plan Setting", typeof(MyPages.PlanSettingController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "Notifications/WhatsApp", typeof(MyPages.WhatsAppController), icon: "fab fa-whatsapp")]
