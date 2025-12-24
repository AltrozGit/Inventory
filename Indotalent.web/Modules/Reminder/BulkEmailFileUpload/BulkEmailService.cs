using DocumentFormat.OpenXml.Spreadsheet;
using Indotalent.Reminder;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Mail; // For email validation

namespace Indotalent.Web.Modules.Reminder.BulkEmailFileUpload
{
    public class BulkEmailService
    {
        private readonly ILogger<BulkEmailService> _logger;
        readonly static string rootFilePath = @"App_Data/upload/";

        public BulkEmailService(ILogger<BulkEmailService> logger)
        {
            _logger = logger;
        }

        public List<BulkEmailFileUploadRow> ReadBulkEmailData(string filePath, int tenantId, int insertUserId)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty.");
            }
            
            var bulkEmailData = new List<BulkEmailFileUploadRow>();
            var fileInfo = new FileInfo(rootFilePath + filePath);
            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException("The file was not found.", filePath);
            }

            try
            {
                using (var package = new ExcelPackage(fileInfo))
                {
                    var worksheets = package.Workbook.Worksheets;
                    if (worksheets.Count == 0)
                    {
                        throw new InvalidOperationException("No worksheets found in the Excel file.");
                    }

                    foreach (var worksheet in worksheets)
                    {
                        int rowCount = worksheet.Dimension?.Rows ?? 0;

                        // Skip 1st header row
                        for (int row = 2; row <= rowCount; row++)
                        {
                            var recipientName = worksheet.Cells[row, 2].Text;
                            var toEmail = worksheet.Cells[row, 3].Text.Trim();  // Trim email
                            var cc = worksheet.Cells[row, 4].Text.Trim();       // Trim cc
                            var subject = worksheet.Cells[row, 5].Text;
                            var attachment = worksheet.Cells[row, 6].Text;
                            var body = worksheet.Cells[row, 7].Text;

                            var toEmailAddresses = toEmail.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            var validToEmails = new List<string>();

                            foreach (var email in toEmailAddresses)
                            {
                                var trimmedEmail = email.Trim();
                                if (IsValidEmail(trimmedEmail))
                                {
                                    validToEmails.Add(trimmedEmail);
                                }
                                else
                                {
                                    _logger.LogWarning("Row {Row}: Invalid ToEmail '{Email}'. Skipping this email.", row, trimmedEmail);
                                }
                            }

                            // Skip record if no valid ToEmail addresses
                            if (validToEmails.Count == 0)
                            {
                                _logger.LogError("Row {Row}: No valid ToEmail addresses found. Skipping record.", row);
                                continue;
                            }

                            // Skip record if Subject is empty
                            if (string.IsNullOrWhiteSpace(subject))
                            {
                                _logger.LogError("Row {Row}: Subject is empty. Skipping record.", row);
                                continue;
                            }

                            // Log a warning if CC is empty or invalid but do not skip the record
                            if (string.IsNullOrWhiteSpace(cc) || !IsValidEmail(cc))
                            {
                                _logger.LogWarning("Row {Row}: CC is missing or invalid. Inserting record but CC will be empty.", row);
                                cc = string.Empty; // Set CC as empty if invalid
                            }


                            // Add valid row data to the list
                            var rowData = new BulkEmailFileUploadRow
                            {
                                CompanyName = worksheet.Cells[row, 1].Text,
                                RecipientName = recipientName,
                                ToEmail = toEmail,
                                CC = cc,
                                Subject = subject,
                                Attachment = attachment,
                                Body = body,
                                Placeholder = worksheet.Cells[row, 8].Text,
                                Placeholder1 = worksheet.Cells[row, 9].Text,
                                IsSent = false, // Default to false
                                TenantId = tenantId,
                                InsertUserId = insertUserId,
                                
                            };

                            bulkEmailData.Add(rowData);
                        }
                    }
                }
            }
            catch (ValidationException ex)
            {
                _logger.LogError("Validation error: {Message}", ex.Message);
                throw new ValidationException($"Error reading bulk email data: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error reading bulk email data from the Excel file: {Message}", ex.Message);
                throw new InvalidOperationException("Error reading bulk email data from the Excel file.", ex);
            }

            return bulkEmailData;
        }

        // Helper method to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        
    }
}
