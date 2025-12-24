using Indotalent.Administration;
using Indotalent.AppServices;
using Indotalent.Bills;
using Indotalent.Common;
using Indotalent.Inventory;
using Indotalent.Material;
using Indotalent.Material_Request;
using Indotalent.Membership;
using Indotalent.Merchandise;
using Indotalent.Migrations;
using Indotalent.Navigation;
using Indotalent.Projects;
using Indotalent.Purchase;
using Indotalent.Reminder;
using Indotalent.Sales;
using Indotalent.Settings;
using Indotalent.Web;
using System.Data;
using System.Text;
using Serenity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Serenity;
using static Indotalent.Web.Modules.Common.Common;
using Indotalent.General;




namespace Indotalent.Web.Modules.Common
{
    internal static class DbHelper
    {
        #region Get

        internal static ProductRow GetProducts(int ProductId)
        {
            using (var connection = AppStatics.SqlConnections.NewFor<ProductRow>())
            {
                return connection.ById<ProductRow>(ProductId);
            }
        }

		

		#endregion


		#region Update
		internal static void UpdateProduct(ProductRow ProductRow)
        {
            using (var connection = AppStatics.SqlConnections.NewFor<ProductRow>())
            {
                connection.UpdateById(ProductRow);
            }
        }

        #endregion
    }
}
