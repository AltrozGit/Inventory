using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Indotalent.WhatsApp;
using Indotalent.WhatsApp.Endpoints;
using Microsoft.Data.SqlClient;
using Serenity.Data;

namespace Indotalent.Web.Modules.Purchase.Vendor
{
	public class SmartChatApiClient
	{
		private readonly string apiUrl = "https://smartchatapi.com/w4b_altroztech/Api/send_template_message";
		private readonly string token = "yuXkaA0P"; // Token to be included in the headers

		public async Task<bool> SendMessage(
			string senderWhatsappNumber,
			string templateName,
			string broadcastName,
			string Url,
			string parameterValue1)
		{
			using var client = new HttpClient();
			// Add the token to the request headers
			client.DefaultRequestHeaders.Add("token", token);

			var requestData = new
			{
				sender_whatsapp_number = senderWhatsappNumber,
				template_name = templateName,
				broadcast_name = broadcastName,
				url = Url,
				parameter_value1 = parameterValue1
			};

			try
			{
				var jsonContent = JsonConvert.SerializeObject(requestData);
				var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

				HttpResponseMessage response = await client.PostAsync(apiUrl, content);
				response.EnsureSuccessStatusCode();  // Throws an exception for non-2xx status codes
				return response.IsSuccessStatusCode;
			}
			catch (HttpRequestException e)
			{
				Console.WriteLine($"Request error: {e.Message}");
				return false;
			}
		}

		public async Task<bool> SendBulkMessages(
			IEnumerable<string> phoneNumber,
			string templateName,
			string broadcastName,
			string Url,
			string parameterValue1,
			IDbConnection connection)
		{
			foreach (var phoneNumbers in phoneNumber)
			{
				try
				{
					var success = await SendMessage(phoneNumbers, templateName, broadcastName, Url, parameterValue1);

					if (success)
					{
						var whatsAppId = GetIdByPhoneNumber(templateName, phoneNumbers, connection);

						if (whatsAppId != null)
						{
							connection.UpdateById(new WhatsAppTemplateRow
							{
								Id = whatsAppId.Value,
								IsSent = true
							});
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error sending message: " + ex.Message);
				}
			}
			return true;
		}

		private int? GetIdByPhoneNumber(string template_Name, string phoneNumbers, IDbConnection connection)
		{
			// Ensure the parameter names match the query's placeholder names
			var whatsApp = connection.QueryFirstOrDefault<WhatsAppTemplateRow>(
				"SELECT Id FROM WhatsAppTemplate WHERE PhoneNumber = @phoneNumber AND TemplateName = @templateName",
				new { templateName = template_Name, phoneNumber = phoneNumbers });

			return whatsApp?.Id;
		}
	}
}
