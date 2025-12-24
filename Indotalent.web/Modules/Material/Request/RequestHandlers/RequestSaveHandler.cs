using Indotalent.Administration;
using Indotalent.Projects;
using Indotalent.Reminder;
using Microsoft.Office.Interop.Excel;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using System.Linq;
using static MVC.Views.Administration;
using static MVC.Views.Projects;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Material.RequestRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Material.RequestRow;

namespace Indotalent.Material
{
	public interface IRequestSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

	public class RequestSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IRequestSaveHandler
	{
		public RequestSaveHandler(IRequestContext context)
			 : base(context)
		{
		}
		protected override void BeforeSave()
		{
			base.BeforeSave();


			if (Row.ItemList != null)
			{
				Row.TotalQtyRequest = 0;
				foreach (var item in Row.ItemList)
				{
                 
                    Row.TotalQtyRequest += item.QtyRequest;


				}


			}



			if (this.IsCreate)
			{
				if (Row.Number.ToLower().Equals("auto"))
				{
					var tenant = UnitOfWork.Connection.ById<TenantRow>(Row.TenantId);
					var request = new GetNextNumberRequest()
					{
						Prefix = tenant.MaterialRequestNumberUseDate.Value ? tenant.MaterialRequestNumberPrefix + "/" + DateTime.Now.ToString("yyyyMMdd") : tenant.MaterialRequestNumberPrefix,
						Length = tenant.MaterialRequestNumberLength.Value
					};
					var respone = MultiTenantHelper.GetNextNumber(UnitOfWork.Connection, request, MyRow.Fields.Number, tenant.TenantId);
					Row.Number = respone.Serial;
				}

			}


		}




		protected override void AfterSave()
		{


			base.AfterSave();
            this.UpdatePMRDetailQtyRequestAndTotalQtyRequest();


   //         if (this.IsCreate)
   //{


            //             var emailnotification = new EmailNotificationRow();


            //	emailnotification.ToEmail = "pratiksha6215@gmail.com";
            //	emailnotification.Subject = "TestingMAil";
            //	emailnotification.Body = "Material Request Successfully created";
            //	emailnotification.Attachment = null;
            //	emailnotification.IsSent = false;
            //	emailnotification.SentOn = null;  // or DateTime.UtcNow
            //	emailnotification.RetryCount = 0;
            //	emailnotification.InsertUserId = 1;
            //	emailnotification.InsertDate = DateTime.Now;
            //	emailnotification.IsActive = true;
            //	emailnotification.BulkEmailSenderId = 11;
            //	emailnotification.BulkEmailSenderId = 194;
            //	emailnotification.CC = "pawarpratiksha823@gmail.com";
            //	emailnotification.RecipientName = "Pratiksha";
            //	emailnotification.CompanyName = "abc pvt ltd";
            //	emailnotification.Placeholder = "23.01.2025";
            //	emailnotification.Placeholder1 = "25.09.2024";
            //	emailnotification.ScheduledDate = DateTime.Now;
            //	emailnotification.FromAddress = "altrozdemo@gmail.com";
            //	emailnotification.UpdateDate = null;
            //	emailnotification.UpdateUserId = null;

            //	emailnotification.TenantId = Row.TenantId;

            //	connection.InsertAndGetID(emailnotification);


            //}




        }



        private void UpdatePMRDetailQtyRequestAndTotalQtyRequest()
        {
            var connection = UnitOfWork.Connection;

            // ProjectMaterialRequestRow details
            var pmrRowList = Dapper.SqlMapper.Query<ProjectMaterialRequestRow>(
                connection, @$"
    SELECT * 
    FROM ProjectMaterialRequest 
    WHERE Id = {Row.ProjectMaterialRequestId} 
    ",
                null,
                commandType: CommandType.Text
            ).ToList();

            // ProjectMaterialRequestDetailRow details
            var pmrdetailRowList = Dapper.SqlMapper.Query<ProjectMaterialRequestDetailRow>(
                connection, @$"
    SELECT * 
    FROM ProjectMaterialRequestDetail 
    WHERE ProjectMaterialRequestId = {Row.ProjectMaterialRequestId} 
    ",
                null,
                commandType: CommandType.Text
            ).ToList();

            var updatedMRDetailList = Row.ItemList.ToList();

            foreach (var updatedPMRDetail in updatedMRDetailList)
            {
                foreach (var pmrdetailRow in pmrdetailRowList)
                {
                    if (updatedPMRDetail.ProductId == pmrdetailRow.ProductId)
                    {
                        if (updatedPMRDetail.QtyRequest != pmrdetailRow.QtyRequest)
                        {

                            pmrdetailRow.PendingMaterialRequestQty = pmrdetailRow.PendingMaterialRequestQty - updatedPMRDetail.QtyRequest;
                            pmrdetailRow.IsCompleteMRCreated = false;

                            if(pmrdetailRow.PendingMaterialRequestQty == 0)
                            {
                                pmrdetailRow.IsCompleteMRCreated = true;
                            }

                            connection.Execute(@"
                        UPDATE ProjectMaterialRequestDetail 
                        SET PendingMaterialRequestQty = @PendingMaterialRequestQty, 
                            IsCompleteMRCreated = @IsCompleteMRCreated 
                        WHERE Id = @Id
                    ", new
                            {
                                PendingMaterialRequestQty = pmrdetailRow.PendingMaterialRequestQty,
                                IsCompleteMRCreated = pmrdetailRow.IsCompleteMRCreated,
                                Id = pmrdetailRow.Id
                            }, commandType: CommandType.Text);
                        }
                       else if (updatedPMRDetail.QtyRequest == pmrdetailRow.QtyRequest)
                        {

                            pmrdetailRow.PendingMaterialRequestQty = pmrdetailRow.PendingMaterialRequestQty - updatedPMRDetail.QtyRequest;

                            if (pmrdetailRow.PendingMaterialRequestQty == 0)
                            {
                                pmrdetailRow.IsCompleteMRCreated = true;
                            }

                            connection.Execute(@"
                        UPDATE ProjectMaterialRequestDetail 
                        SET PendingMaterialRequestQty = @PendingMaterialRequestQty, 
                            IsCompleteMRCreated = @IsCompleteMRCreated 
                        WHERE Id = @Id
                    ", new
                            {
                                PendingMaterialRequestQty = pmrdetailRow.PendingMaterialRequestQty,
                                IsCompleteMRCreated = pmrdetailRow.IsCompleteMRCreated,
                                Id = pmrdetailRow.Id
                            }, commandType: CommandType.Text);
                        }
                    }
                }
            }

          
        }

    }

}