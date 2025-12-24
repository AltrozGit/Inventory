using Serenity.ComponentModel;
using System.ComponentModel;

namespace Indotalent.Web.Common
{
    public class Enums
    {
        [EnumKey("Smtp.Host")]
        public enum SmtpHost
        {
            [Description("smtp.gmail.com")]
            Gmail = 1,
            [Description("smtp.office365.com")]
            Office365 = 2,
            [Description("smtp.yahoo.com")]
            Yahoo = 3
        }

        [EnumKey("Smtp.Port")]
        public enum SmtpPort
        {
            [Description("25")]
            Port25 = 25,
            [Description("465")]
            Port465 = 465,
            [Description("587")]
            Port587 = 587
        }

        [EnumKey("Smtp.SourceSystem")]
        public enum SourceSystem
        {
            [Description("Inventory")]
            Inventory = 1,
            [Description("Notification")]
            Notification = 2,
            [Description("HRMS")]
            HRMS = 3
        }
        [EnumKey("Custom.EmailSentStatus")]
        public enum EmailSentStatus
        {
            Pending = 0,
            Successful = 1,
            Cancelled = 2
        }

		
		[EnumKey("PurchaseTax.PurchaseTaxType")]
        public enum PurchaseTaxType
        {
            [Description("GST")]
            GST = 1,
            [Description("TCS")]
            TCS = 2,
            [Description("TDS")]
            TDS = 3
          
        }


        [EnumKey("SalesTax.SalesTaxType")]
        public enum SalesTaxType
        {
            [Description("GST")]
            GST = 1,
            [Description("TCS")]
            TCS = 2,
            [Description("TDS")]
            TDS = 3

        }
    }
}
