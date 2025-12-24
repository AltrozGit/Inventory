using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Reporting;
using System;
using System.Collections.Generic;

namespace Indotalent.Sales
{
    [Report("InvoicePrint")]
    [ReportDesign(MVC.Views.Sales.Invoice.InvoicePrint)]
    [RequiredPermission("Sales:Invoice")]
    public class InvoicePrintModel : IReport, ICustomizeHtmlToPdf
    {
        public InvoicePrintModel(ISqlConnections sqlConnections)
        {
            SqlConnections = sqlConnections ?? throw new ArgumentNullException(nameof(sqlConnections));
        }

        public int Id { get; set; }

        protected ISqlConnections SqlConnections { get; }

        public object GetData()
        {
            var data = new InvoicePrintData();

            using (var connection = SqlConnections.NewFor<InvoiceRow>())
            {
                var h = InvoiceRow.Fields;
                data.Header = connection.TryById<InvoiceRow>(Id, q => q
                     .SelectTableFields()
                     .Select(h.SalesOrderNumber)
                     .Select(h.DispatchedBy)
                     .Select(h.DispatchedTo)
                     .Select(h.PlaceOfSupply)
                     .Select(h.CustomerId)
                     .Select(h.FinalTotalPostTDS_TCS)); 

                var d = InvoiceDetailRow.Fields;
                data.Details = connection.List<InvoiceDetailRow>(q => q
                    .SelectTableFields()
                    .Select(d.ProductName)
                    .Select(d.InternalCode)
                    .Where(d.InvoiceId == Id));

             
                var cust = CustomerRow.Fields;
                data.Customer = connection.TryById<CustomerRow>(data.Header.CustomerId, q => q
                     .SelectTableFields()
                     .Select(cust.StateName));

                var c = Settings.MyCompanyRow.Fields;
                data.Company = connection.TryById<Settings.MyCompanyRow>(data.Header.TenantId, q => q
                     .SelectTableFields()
                      .Select(c.StateName));
            }
            data.AmountInWords = NumberToWords((decimal)(data.Header.FinalTotalPostTDS_TCS ?? 0));

            return data;
        }

        public static string NumberToWords(decimal number)
        {
            if (number == 0)
                return "Zero Rupees Only";

            long intPart = (long)Math.Floor(number);
            int decimalPart = (int)((number - intPart) * 100);

            string words = $"{NumberToWordsHelper(intPart)} Rupees";
            if (decimalPart > 0)
            {
                words += $" and {NumberToWordsHelper(decimalPart)} Paise";
            }

            return words + " Only";
        }

        private static string NumberToWordsHelper(long number)
        {
            if (number == 0) return "";

            if (number < 0)
                return "Minus " + NumberToWordsHelper(Math.Abs(number));

            string[] unitsMap = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                          "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
                          "Seventeen", "Eighteen", "Nineteen" };
            string[] tensMap = { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            string words = "";

            if ((number / 10000000) > 0)
            {
                words += NumberToWordsHelper(number / 10000000) + " Crore ";
                number %= 10000000;
            }

            if ((number / 100000) > 0)
            {
                words += NumberToWordsHelper(number / 100000) + " Lakh ";
                number %= 100000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWordsHelper(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWordsHelper(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words.Trim();
        }



        public void Customize(IHtmlToPdfOptions options)
        {
        }
    }

    public class InvoicePrintData
    {
        public InvoiceRow Header { get; set; }
        public List<InvoiceDetailRow> Details { get; set; }
        public CustomerRow Customer { get; set; }
        public Settings.MyCompanyRow Company { get; set; }

        public string AmountInWords { get; set; } // ? Add this
    }
}
