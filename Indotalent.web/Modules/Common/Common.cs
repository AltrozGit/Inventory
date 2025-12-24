using Microsoft.Extensions.DependencyInjection;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.Collections.Generic;
using System.Globalization;





namespace Indotalent.Web.Modules.Common
{
    public class Common
    {

        public static class AppStatics
        {
            public static ISqlConnections SqlConnections { get; set; }

            public static void InitializeServices(IServiceProvider services)
            {
                SqlConnections = services.GetRequiredService<ISqlConnections>();
            }
        }
    }
}
