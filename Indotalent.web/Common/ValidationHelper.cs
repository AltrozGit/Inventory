using OfficeOpenXml;
using System.IO;
using System.Text;
using System;

namespace Indotalent.Web.Common
{
    internal static class ValidationHelper

    {
        internal static void ValidateBulkEmailData(string FilePath)
        {
            try
            {
                string rootFilePath = @"App_Data/upload/";

                using (var package = new ExcelPackage(new FileInfo(rootFilePath + FilePath)))
                {
                    ExcelWorksheets worksheets = package.Workbook.Worksheets;
                    StringBuilder validationSummary = new StringBuilder();

                    foreach (var worksheet in worksheets)
                    {
                        int rowCount = worksheet.Dimension.Rows;
                        int colCount = worksheet.Dimension.Columns;

                        // skip 1st header row
                        for (int rowIndex = 2; rowIndex <= rowCount; rowIndex++)
                        {
                        }
                    }

                    if (validationSummary.Length > 0)
                    {
                        throw new Exception("Validation error(s) found:\n" + validationSummary.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred during timesheet validation: " + ex.Message);
            }
        }

    }
}
