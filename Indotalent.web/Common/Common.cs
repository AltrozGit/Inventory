using Microsoft.Extensions.DependencyInjection;
using Serenity.ComponentModel;
using Serenity.Data;
using System;

namespace Indotalent.Web.Common
{



    public class CommonConstant
    {
        public const string SubscrtionTemplateName = "Subscription Reminder";
        public const string SubscriptionReminderSubject = "Subscription Expiry Reminder for Plan: {0}";

        public const string SubscriptionReminderMessage =
      "<p>Hello <b>{0}</b>,</p>" +
      "<p>Your subscription for <b>{1}</b> will expire on <b>{2}</b>.</p>" +
      "<p>Please renew in time. </p><p>Thank You.</p>";

    }
    public static class AppStatics
    {
        public static ISqlConnections SqlConnections { get; set; }

        public static void InitializeServices(IServiceProvider services)
        {
            SqlConnections = services.GetRequiredService<ISqlConnections>();
        }
    }
 
}
