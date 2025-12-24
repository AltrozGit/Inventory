using Indotalent.Web.Modules.Purchase.Vendor;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Tls;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static MVC.Views.Purchase;
using MyRow = Indotalent.WhatsApp.WhatsAppTemplateRow;

namespace Indotalent.WhatsApp.Endpoints
{
    [Route("Services/WhatsApp/WhatsAppTemplate/[action]")]
	
	[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class WhatsAppTemplateController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IWhatsAppTemplateSaveHandler handler)
        {
            return handler.Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IWhatsAppTemplateSaveHandler handler)
        {
            return handler.Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IWhatsAppTemplateDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IWhatsAppTemplateRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IWhatsAppTemplateListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IWhatsAppTemplateListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.WhatsAppTemplateColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "WhatsAppTemplateList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }

		[HttpPost]
		public async Task<bool> SendWhatsAppMessage(IDbConnection connection, SendWhatsAppMessageRequest request)
		{
			if (request.VendorId == null)
				throw new ArgumentNullException("VendorId", "VendorId is required.");

			// Fetch vendor details
			var vendor = connection.TryById<MyRow>(request.VendorId);
			if (vendor == null)
				throw new ValidationError("Vendor not found.");
			
			if (string.IsNullOrWhiteSpace(vendor.PhoneNumber))
				throw new ValidationError("Vendor does not have a valid phone number.");

			// Send message using SmartChat API
			try
			{
				var apiClient = new SmartChatApiClient();
				bool isSent = await apiClient.SendMessage(
					vendor.PhoneNumber,
                    vendor.TemplateName,
                    vendor.BroadcastName,
                    vendor.Url,
					vendor.Name);
				
				var updateRow = new MyRow 
				{
					Id = vendor.Id,
					IsSent = isSent
				};
				connection.UpdateById(updateRow);
				
				return isSent;

			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error sending WhatsApp Message: { ex.Message}");
				return false;
				//var errorMessage = ex.Message;
				//var stackTrace = ex.StackTrace;
				//throw new ValidationError($"Failed to send WhatsApp message: {errorMessage}.StackTrace:{stackTrace}");	
			}
		}


		[HttpPost]
		public async Task<bool> BulkMessages(IDbConnection connection, SendWhatsAppMessageRequest request)
		{
			
			if (request.VendorId == null)
				throw new ArgumentNullException("VendorId", "VendorId is required.");

			// Fetch vendor details
			var vendor = connection.TryById<MyRow>(request.VendorId);
			if (vendor == null)
				throw new ValidationError("Vendor not found.");


			if (string.IsNullOrWhiteSpace(vendor.PhoneNumber))
				throw new ValidationError("Vendor does not have a valid phone number.");

			try
			{ 
			SqlQuery sql = new SqlQuery().From("WhatsAppTemplate").Distinct(true).Select("PhoneNumber");
			var phoneNumbers = connection.Query<String>(sql).ToList();
			var bulkMessageService = new SmartChatApiClient();
			await bulkMessageService.SendBulkMessages(phoneNumbers,
					vendor.TemplateName,
					vendor.BroadcastName,
					vendor.Url,
					vendor.Name,
					connection);
			
				/*connection.UpdateById(new MyRow
				{
					Id = vendor.Id,
					IsSent = true
				});*/

				return true;
			}
			
			catch (Exception ex)
			{
				Console.WriteLine($"Error sending WhatsApp Message: {ex.Message}");
				return false;
				//var errorMessage = ex.Message;
				//var stackTrace = ex.StackTrace;
				//throw new ValidationError($"Failed to send WhatsApp message: {errorMessage}.StackTrace:{stackTrace}");
			}		
			
		
		}

	}
	public class SendWhatsAppMessageRequest : ServiceRequest
	{
		public int? VendorId { get; set; }
		//public bool? IsSent { get; set; }
	}
}