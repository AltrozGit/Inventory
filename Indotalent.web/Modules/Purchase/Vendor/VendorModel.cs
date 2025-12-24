using Serenity.Services;
using System;

namespace Indotalent.Web.Modules.Purchase.Vendor
{ 
    public class MyActionRequest : ServiceRequest
	{
		public int MyId { get; set; }
	}
	public class MyActionResponse : ServiceResponse
	{
		public string Rezult { get; set; }
	}

}
