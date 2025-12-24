using Indotalent.Inventory;
using Indotalent.Material;

using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Reporting;
using System;
using System.Collections.Generic;

namespace Indotalent.Material
{
    [Report("RequestPrint")]
    [ReportDesign(MVC.Views.Material.Request.RequestPrint)]
    [RequiredPermission("Material:Request")]
    public class RequestPrintModel : IReport, ICustomizeHtmlToPdf
    {
        public RequestPrintModel(ISqlConnections sqlConnections)
        {
            SqlConnections = sqlConnections ?? throw new ArgumentNullException(nameof(sqlConnections));
        }

        public int Id { get; set; }

        protected ISqlConnections SqlConnections { get; }

        public object GetData()
        {
            var data = new RequestPrintData();

            using (var connection = SqlConnections.NewFor<RequestRow>())
            {

                var h = RequestRow.Fields;
                data.Header = connection.TryById<RequestRow>(Id, q => q
                     .SelectTableFields()
                    
                     .Select(h.Number));
                    

                var od = RequestDetailRow.Fields;
                data.Details = connection.List<RequestDetailRow>(q => q
                    .SelectTableFields()
                    .Select(od.ProductName)
                    .Select(od.QtyRequest)
                    .Select(od.PurchasePrice)
                    .Where(od.MaterialRequestId == Id));

              

                var c = Settings.MyCompanyRow.Fields;
                data.Company = connection.TryById<Settings.MyCompanyRow>(data.Header.TenantId, q => q
                     .SelectTableFields());
            }

            return data;
        }

        public void Customize(IHtmlToPdfOptions options)
        {
        }
    }

    public class RequestPrintData
    {
        public RequestRow Header { get; set; }
        public List<RequestDetailRow> Details { get; set; }
       
        public Settings.MyCompanyRow Company { get; set; }
    }
}
