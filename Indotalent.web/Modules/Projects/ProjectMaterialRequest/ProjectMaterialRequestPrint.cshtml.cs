using Indotalent.Inventory;
using Indotalent.Material;

using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Reporting;
using System;
using System.Collections.Generic;

namespace Indotalent.Projects
{
    [Report("ProjectMaterialRequestPrint")]
    [ReportDesign(MVC.Views.Projects.ProjectMaterialRequest.ProjectMaterialRequestPrint)]
    [RequiredPermission("Projects:ProjectMaterialRequest")]
    public class ProjectMaterialRequestPrintModel : IReport, ICustomizeHtmlToPdf
    {
        public ProjectMaterialRequestPrintModel(ISqlConnections sqlConnections)
        {
            SqlConnections = sqlConnections ?? throw new ArgumentNullException(nameof(sqlConnections));
        }

        public int Id { get; set; }

        protected ISqlConnections SqlConnections { get; }

        public object GetData()
        {
            var data = new ProjectMaterialRequestPrintData();
            using (var connection = SqlConnections.NewFor<ProjectMaterialRequestRow>())
            {
                var h = ProjectMaterialRequestRow.Fields;
                data.Header = connection.TryById<ProjectMaterialRequestRow>(Id, q => q
                .SelectTableFields()
                .Select(h.Number));


                var od = ProjectMaterialRequestDetailRow.Fields;
                data.Details = connection.List<ProjectMaterialRequestDetailRow>(q => q
                    .SelectTableFields()
                    .Select(od.ProductName)
                    .Select(od.QtyRequest)
                    .Select(od.PurchasePrice)
                    .Where(od.ProjectMaterialRequestId == Id));



                var c = Indotalent.Settings.MyCompanyRow.Fields;
                data.Company = connection.TryById<Indotalent.Settings.MyCompanyRow>(data.Header.TenantId, q => q
                     .SelectTableFields()
                       .Select(c.StateId)
                 .Select(c.StateName));

            }
           return data;
        }
        public void Customize(IHtmlToPdfOptions options)
        {
        }
    }
    public class ProjectMaterialRequestPrintData
    {
        public ProjectMaterialRequestRow Header { get; set; }
        public List<ProjectMaterialRequestDetailRow> Details { get; set; }
        public Indotalent.Settings.MyCompanyRow Company { get; set; }
    }
}
