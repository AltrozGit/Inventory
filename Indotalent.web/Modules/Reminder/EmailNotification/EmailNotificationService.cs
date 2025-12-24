using Indotalent.Reminder;
using Indotalent.Web.Modules.Reminder.BulkEmailFileUpload;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Indotalent.Web.Modules.Reminder.EmailNotification
{
    public class EmailNotificationService
    {
        private readonly IEmailNotificationSaveHandler _emailNotificationSaveHandler;
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<EmailNotificationService> _logger;
       
        private static readonly Regex emailRegex = new Regex(
    @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
    RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public EmailNotificationService(
            IEmailNotificationSaveHandler emailNotificationSaveHandler,
            IConfiguration _configuration,
            IWebHostEnvironment webHostEnvironment,
            ILogger<EmailNotificationService> logger)
        {
            _emailNotificationSaveHandler = emailNotificationSaveHandler;
            configuration = _configuration;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        public void InsertIntoEmailNotification(IEnumerable<BulkEmailFileUploadRow> bulkEmailData, IUnitOfWork uow, long bulkEmailSenderId)
        {
            // Retrieve sender information
            var bulkEmailSender = uow.Connection.TryById<BulkEmailFileUploadRow>(bulkEmailSenderId);
            if (bulkEmailSender == null)
            {
                throw new InvalidOperationException("BulkEmailSender record not found.");
            }
            var basePath = Path.Combine(_webHostEnvironment.ContentRootPath);
            var uploadPath = configuration["UploadSettings:Path"];

            if (string.IsNullOrEmpty(uploadPath))
            {
                _logger.LogWarning("Upload path is not configured in app settings.");
                return;
            }
            var scheduledDate = bulkEmailSender.ScheduledDate;
           

            var fromAddress = bulkEmailSender.FromAddress;
            var attachmentsList = GetAttachmentsList(bulkEmailSender.UploadAttachments);
            var validEmailDataList = new List<EmailNotificationRow>();
            var skippedEmailsMessages = new List<string>();
            string firstBody = "";

            foreach (var emailData in bulkEmailData)
            {
                if (string.IsNullOrEmpty(firstBody))
                {
                    firstBody = emailData.Body;
                }
                // Validate recipient email
                if (!ValidateRecipientEmail(emailData, skippedEmailsMessages))
                    continue;

                // Process attachments
                var sanitizedAttachments = GetSanitizedAttachments(emailData, attachmentsList,basePath,uploadPath,skippedEmailsMessages);
                if (!string.IsNullOrEmpty(emailData.Attachment) && !sanitizedAttachments.Any())
                {
                    var message = $"Attachment {emailData.Attachment} specified in the Excel file for recipient {emailData.RecipientName} is not uploaded on the UI. Email will not be sent.";
                    _logger.LogWarning(message);
                    skippedEmailsMessages.Add(message);
                    continue;
                }
                // Check subject and body
             
                if (string.IsNullOrEmpty(emailData.Subject))
                {
                    LogSkippedEmail($"Subject is missing for recipient {emailData.RecipientName}. Skipping email.", skippedEmailsMessages);
                    continue;
                }
                if (string.IsNullOrEmpty(emailData.Body))
                {
                    emailData.Body = firstBody;
                }
                // Insert each ToEmail record individually
                foreach (var toEmail in emailData.ToEmail.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var trimmedEmail = toEmail.Trim();
                    if (!IsValidEmail(trimmedEmail))
                    {
                        LogSkippedEmail($"Invalid ToEmail {trimmedEmail} for recipient {emailData.RecipientName}. Skipping email.", skippedEmailsMessages);
                        continue;
                    }

                    var emailNotification = CreateEmailNotification(emailData, trimmedEmail, fromAddress, sanitizedAttachments, scheduledDate, bulkEmailSenderId);
                    //  SaveEmailNotification(uow, emailNotification);
                    validEmailDataList.Add(emailNotification);
                }
            }
            if (!validEmailDataList.Any())
            {
                _logger.LogInformation("No valid records found. All emails were skipped.");
                throw new ValidationException("All records in the file are invalid. No entries were saved.");
            }

            // Insert valid records into the database
            foreach (var emailNotification in validEmailDataList)
            {
                SaveEmailNotification(uow, emailNotification);
            }
            if (skippedEmailsMessages.Any())
            {
                _logger.LogInformation("The following emails were skipped:");
                skippedEmailsMessages.ForEach(msg => _logger.LogInformation(msg));
            }
        }

        // Helper methods

        private List<UploadAttachmentModel> GetAttachmentsList(string uploadAttachments)
        {
            return string.IsNullOrEmpty(uploadAttachments)
                ? new List<UploadAttachmentModel>()
                : JsonConvert.DeserializeObject<List<UploadAttachmentModel>>(uploadAttachments);
        }

        private List<string> GetSanitizedAttachments(BulkEmailFileUploadRow emailData, List<UploadAttachmentModel> attachmentsList, string basePath, string uploadPath, List<string> skippedEmailsMessages)
        
            {
            var emailAttachments = attachmentsList
                .Where(a => emailData.Attachment != null && emailData.Attachment.Contains(a.OriginalName))
                .Select(a => Path.Combine(basePath, uploadPath, a.FileName))
                .Select(path => path.Replace("~", "").Replace("/", Path.DirectorySeparatorChar.ToString()).Replace("\\\\", "\\"))
                .ToList();

            if (!emailAttachments.Any())
            {
                LogSkippedEmail($"Attachment {emailData.Attachment} specified for {emailData.RecipientName} is not found. Email will be sent without attachment.", skippedEmailsMessages);
            }

            return emailAttachments;
        }

        private bool ValidateRecipientEmail(BulkEmailFileUploadRow emailData, List<string> skippedEmailsMessages)
        {
            if (string.IsNullOrWhiteSpace(emailData.ToEmail))
            {
                LogSkippedEmail($"ToEmail is missing for recipient {emailData.RecipientName}. Skipping email.", skippedEmailsMessages);
                return false;
            }

            var toEmails = emailData.ToEmail.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (!toEmails.Any(email => IsValidEmail(email.Trim())))
            {
                LogSkippedEmail($"No valid ToEmail found for recipient {emailData.RecipientName}. Skipping email.", skippedEmailsMessages);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            return emailRegex.IsMatch(email);
        }

//        private static readonly HashSet<string> KnownDomains = new HashSet<string>
//{
//    "gmail.com", "yahoo.com", "outlook.com", "hotmail.com", "icloud.com","liveinspirred.com","altroztech.com"
//    // Add other known domains as needed
//};

        //private bool IsValidEmailDomain(string email)
        //{
        //    try
        //    {
        //        var domain = email?.Split('@')[1];

        //        // Validate common domain patterns
        //        if (string.IsNullOrEmpty(domain) || !domain.Contains(".") || domain.Split('.').Any(part => part.Length < 2))
        //            return false;

        //        // Check against the known domains list for common domains
        //        return KnownDomains.Contains(domain.ToLower());
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        private void LogSkippedEmail(string message, List<string> skippedEmailsMessages)
        {
            _logger.LogWarning(message);
            skippedEmailsMessages.Add(message);
        }

        private EmailNotificationRow CreateEmailNotification(BulkEmailFileUploadRow emailData, string toEmail, string fromAddress, List<string> sanitizedAttachments, DateTime? scheduledDate, long bulkEmailSenderId)
        {
            return new EmailNotificationRow
            {
                FromAddress = fromAddress,
                ToEmail = toEmail,
                CC = string.Join(",", emailData.CC?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Where(IsValidEmail) ?? Enumerable.Empty<string>()),
                Subject = emailData.Subject,
                Body = emailData.Body,
                Attachment = sanitizedAttachments.Any() ? string.Join(",", sanitizedAttachments) : null,
                IsSent = emailData.IsSent,
                RecipientName = emailData.RecipientName,
                CompanyName = emailData.CompanyName,
                Placeholder = emailData.Placeholder,
                Placeholder1 = emailData.Placeholder1,
                TenantId = emailData.TenantId,
                //InsertUserId = emailData.InsertUserId,
                BulkEmailSenderId = (int?)bulkEmailSenderId,
                IsActive = true,
                ScheduledDate = scheduledDate
                
            };
        }

        private void SaveEmailNotification(IUnitOfWork uow, EmailNotificationRow emailNotification)
        {
            var saveRequest = new SaveRequest<EmailNotificationRow> { Entity = emailNotification };
            _emailNotificationSaveHandler.Create(uow, saveRequest);
        }

    }
}