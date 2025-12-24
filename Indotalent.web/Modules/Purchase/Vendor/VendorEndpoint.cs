using Indotalent.Purchase;
using Indotalent.Web.Modules.Purchase.Vendor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Numeric;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using OfficeOpenXml.Style;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MyRow = Indotalent.Purchase.VendorRow;

namespace Indotalent.Purchase.Endpoints
{
	[Route("Services/Purchase/Vendor/[action]")]

	[ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]

	
	public class VendorController : ServiceEndpoint
	{

		[HttpPost, AuthorizeCreate(typeof(MyRow))]
		public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
			[FromServices] IVendorSaveHandler handler)
		{
			return handler.Create(uow, request);
		}

		[HttpPost, AuthorizeUpdate(typeof(MyRow))]
		public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
			[FromServices] IVendorSaveHandler handler)
		{
			return handler.Update(uow, request);
		}

		[HttpPost, AuthorizeDelete(typeof(MyRow))]
		public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
			[FromServices] IVendorDeleteHandler handler)
		{
			return handler.Delete(uow, request);
		}

		[HttpPost]
		public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
			[FromServices] IVendorRetrieveHandler handler)
		{
			return handler.Retrieve(connection, request);
		}

		[HttpPost]
		public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
			[FromServices] IVendorListHandler handler)
		{
			return handler.List(connection, request);
		}

		public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
			[FromServices] IVendorListHandler handler,
			[FromServices] IExcelExporter exporter)
		{
			var data = List(connection, request, handler).Entities;
			foreach (var d in data)
			{
				d.Address = d.Street + "  " + d.City + " " + d.ZipCode + "  " + d.StateId + "  " + d.Phone;
			}
			using (var package = new ExcelPackage())
			{
				ExcelWorksheets worksheets = package.Workbook.Worksheets;
				var ws = package.Workbook.Worksheets.Add("Vendor Excel Report");
				ws.Cells["A1"].Value = "Name";
				ws.Cells["B1"].Value = "Address";
				ws.Cells["C1"].Value = "Phone";
				ws.Cells["D1"].Value = "Email";
				ws.Cells["E1"].Value = "GST Number";
				ws.Cells["F1"].Value = "Bank Name";
				ws.Cells["G1"].Value = "Bank Branch";
				ws.Cells["H1"].Value = "Account Number";
				ws.Cells["I1"].Value = "IFSC Code";
				ws.Cells["J1"].Value = "Pan Number";

				int rowIndex = 2;
				foreach (var d in data)
				{
					ws.Cells["A" + rowIndex].Value = d.Name;
					ws.Cells["B" + rowIndex].Value = d.Address;
					ws.Cells["C" + rowIndex].Value = d.Phone;
					ws.Cells["D" + rowIndex].Value = d.Email;
					ws.Cells["E" + rowIndex].Value = d.GSTNumber;
					ws.Cells["F" + rowIndex].Value = d.BankName;
					ws.Cells["G" + rowIndex].Value = d.BankBranch;
					ws.Cells["H" + rowIndex].Value = d.AccountNumber;
					ws.Cells["I" + rowIndex].Value = d.IFSCCode;
					ws.Cells["J" + rowIndex].Value = d.PanNumber;


					rowIndex++;
				}
				int totalRows = rowIndex - 1;
				int lastRow = rowIndex + 1;

				var rangeFirstRow = ws.Cells["A1:J1"];//Formatting Table
				rangeFirstRow.Style.Font.Bold = true;
				rangeFirstRow.Style.Fill.PatternType = ExcelFillStyle.Solid;
				rangeFirstRow.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#c2c2f0")); // or any other color you preferhas context menu

				var excelTable = ws.Tables.Add(ws.Cells["A1:J" + totalRows], "VendorTable");

				excelTable.ShowFirstColumn = false;
				excelTable.ShowLastColumn = false;
				excelTable.ShowRowStripes = true;
				excelTable.ShowColumnStripes = false;

				using (var range = ws.Cells["A1:J" + totalRows])
				{
					range.AutoFitColumns();
					range.Style.Border.Top.Style = ExcelBorderStyle.Thick;
					range.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
					range.Style.Border.Left.Style = ExcelBorderStyle.Thick;
					range.Style.Border.Right.Style = ExcelBorderStyle.Thick;
				}

				var ms = new MemoryStream();
				package.SaveAs(ms);
				ms.Position = 0;

				return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
			  "VendorExcelDownload_" + DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
			}

			//    var bytes = exporter.Export(data, typeof(Columns.VendorColumns), request.ExportColumns);
			//    return ExcelContentResult.Create(bytes, "VendorList_" +
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

			if (string.IsNullOrWhiteSpace(vendor.Phone))
				throw new ValidationError("Vendor does not have a valid phone number.");

			// Send message using SmartChat API
			try
			{
				var apiClient = new SmartChatApiClient();
				await apiClient.SendMessage(
					vendor.Phone,
					"hrms_promotion_212025", // template_name
					"TestingAPI", // broadcast_name
					"https://smartchatapi.com/w4b_altroztech/uploads/header_media/1735798547.jpeg", // url
					vendor.Name);

				return true;
			}
			catch (Exception ex)
			{
				var errorMessage = ex.Message;
				var stackTrace = ex.StackTrace;
				throw new ValidationError($"Failed to send WhatsApp message: {errorMessage}.StackTrace:{stackTrace}");
			}
			
		
			/*return new MyActionResponse
			{
				Success = true
			};*/
		}

		public class SendWhatsAppMessageRequest : ServiceRequest
		{
			public int? VendorId { get; set; }
		}
		/*public class MyActionResponse : ServiceResponse
		{
			public bool Success { get; set; }
		}*/

		

	}


}







