using Indotalent.Administration;
using Indotalent.General;
using Indotalent.Sales;
using Indotalent.Web.Common;
using Indotalent.Web.Modules.Reminder.Subscription;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using MyRow = Indotalent.Reminder.AddBalanceRow;

namespace Indotalent.Reminder.Endpoints
{
    [Route("Services/Reminder/AddBalance/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class AddBalanceController : ServiceEndpoint
    {
        private readonly SubscriptionService _subscriptionService;

        public AddBalanceController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
        [HttpPost]
        public string GetTenantId(IUnitOfWork uow, [FromServices] IUserRetrieveService userRetrieveService)
        {
            var user = (UserDefinition)User.GetUserDefinition(userRetrieveService);
            return user.TenantId.ToString(); // Return the TenantId as string
        }
        [HttpPost]
        public string GetLoggedInUser(IUnitOfWork uow, [FromServices] IUserRetrieveService userRetrieveService)
        {
            var user = (UserDefinition)User.GetUserDefinition(userRetrieveService);
            return user.Email.ToString(); // Return the TenantId as string
        }

        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
       [FromServices] IAddBalanceSaveHandler handler,
       [FromServices] ISubscriptionSaveHandler subscriptionHandler,
       [FromServices] ITenantUnitTransactionSaveHandler tenantUnitTransactionHandler, [FromServices] IUserRetrieveService userRetrieveService, [FromServices] IDueDateReminderSaveHandler reminderHandler

    )
        {
            try
            {
                
                var loggedTenant = GetTenantId(uow, userRetrieveService);
                var loggedInUserEmail = GetLoggedInUser(uow, userRetrieveService);
                var applicationTenantId = request.Entity.ApplicationTenantId;
                request.Entity.TenantId = applicationTenantId;
                // Step 1: Create AddBalance record
                var addBalanceResponse = handler.Create(uow, request);
                

                var tenantId = request.Entity.TenantId;
                var planId = request.Entity.PlanId;
                var customerId=request.Entity.CustomerId;
               
                // Validate tenantId and planId
                if (applicationTenantId == null || planId == null)
                    throw new ValidationError("Application TenantId and PlanId are required!");

                // Fetch the plan details
                var plan = GetPlanDetails(uow, (int)planId);
                if (plan == null)
                    throw new ValidationError("Invalid PlanId or Plan details not found.");

                // Step 2: Fetch previous subscription (if any)
                var previousSubscription = uow.Connection.TryFirst<SubscriptionRow>(q => q
                    .Select(
                        SubscriptionRow.Fields.Id,
                        SubscriptionRow.Fields.PlanId,
                        SubscriptionRow.Fields.CurrentBalanceUnits,
                        SubscriptionRow.Fields.StartDate,
                        SubscriptionRow.Fields.EndDate,
                        SubscriptionRow.Fields.IsActive,
                        SubscriptionRow.Fields.IsArchive,
                        SubscriptionRow.Fields.CustomerId,
                        SubscriptionRow.Fields.CustomerName,
                        SubscriptionRow.Fields.ProductName,

                        SubscriptionRow.Fields.ActiveEndDate,
                        SubscriptionRow.Fields.PlanName,
                        SubscriptionRow.Fields.TotalUnits,
                      
                        SubscriptionRow.Fields.ApplicationTenantId

                    )
                    .Where(SubscriptionRow.Fields.ApplicationTenantId == applicationTenantId.Value)
                    .Where(SubscriptionRow.Fields.PlanId == planId.Value)
                    .Where(SubscriptionRow.Fields.IsArchive == 0)); // Check for non-archived subscriptions
                var previousSubscription1 = uow.Connection.TryFirst<SubscriptionRow>(q => q
                    .Select(
                        SubscriptionRow.Fields.Id,
                        SubscriptionRow.Fields.PlanId,
                        SubscriptionRow.Fields.CurrentBalanceUnits,
                        SubscriptionRow.Fields.StartDate,
                        SubscriptionRow.Fields.EndDate,
                        SubscriptionRow.Fields.IsActive,
                        SubscriptionRow.Fields.IsArchive,
                        SubscriptionRow.Fields.CustomerId,
                        SubscriptionRow.Fields.CustomerName,
                        SubscriptionRow.Fields.ProductName,

                        SubscriptionRow.Fields.ActiveEndDate,
                        SubscriptionRow.Fields.PlanName,
                        SubscriptionRow.Fields.TotalUnits,
                         
                        SubscriptionRow.Fields.ApplicationTenantId

                    )
                    .Where(SubscriptionRow.Fields.ApplicationTenantId == applicationTenantId.Value)

                    .Where(SubscriptionRow.Fields.IsArchive == 0));
                if (previousSubscription1 != null && previousSubscription1.EndDate < DateTime.Today)
                {
                    previousSubscription1.IsActive = false;
                    previousSubscription1.IsArchive = true;
                    subscriptionHandler.Update(uow, new SaveRequest<SubscriptionRow> { Entity = previousSubscription1 });

                    var expiredAudit = _subscriptionService.InsertSubscriptionWithAudit(previousSubscription1, uow);
                    _subscriptionService.SaveSubscriptionAudit(uow, expiredAudit);

                    previousSubscription1 = null;
                }
                double carriedForwardBalance = 0;

                // Step 3: Handle Renewal Plan
                if (plan.Type.Equals("renewal", StringComparison.OrdinalIgnoreCase))
                {
                    DateTime newStartDate = request.Entity.RechargeDate ?? DateTime.Today;
                    DateTime? currentSubscriptionEnd = previousSubscription1?.EndDate;

                    // If there's an active subscription, queue renewal to start after it ends
                    if (previousSubscription1 != null && currentSubscriptionEnd.HasValue)
                    {
                        carriedForwardBalance = previousSubscription1.CurrentBalanceUnits ?? 0;

                        // Do NOT archive/deactivate yet
                        newStartDate = currentSubscriptionEnd.Value.AddDays(1);
                    }

                    var newSubscription = new SubscriptionRow
                    {
                        ApplicationTenantId = tenantId,
                        CustomerId=customerId,
                        PlanId = planId,
                        PlanName = plan.PlanName,
                      ProductName=plan.ProductName,
                        StartDate = newStartDate,
                        EndDate = CalculateEndDate(newStartDate, plan.Frequency),
                        ActiveEndDate = CalculateActiveEndDate(newStartDate, plan.Frequency),
                        TotalUnits = plan.Units,
                        CurrentBalanceUnits = (int?)(plan.Units),
                        IsActive = false, // Only active if no current subscription
                        IsArchive = false
                    };

                    subscriptionHandler.Create(uow, new SaveRequest<SubscriptionRow> { Entity = newSubscription });
                    var insertAudit = _subscriptionService.InsertSubscriptionWithAudit(newSubscription, uow);
                    _subscriptionService.SaveSubscriptionAudit(uow, insertAudit);
                }


                SubscriptionRow regularSubscription = null;
                if (plan.Type.Equals("regular", StringComparison.OrdinalIgnoreCase))
                {
                    if (previousSubscription != null)
                    {
                        // Carry forward the balance
                        previousSubscription.ApplicationTenantId = previousSubscription.ApplicationTenantId;
                        carriedForwardBalance = previousSubscription.CurrentBalanceUnits ?? 0;
                        planId = previousSubscription.PlanId;
                     
                        customerId = previousSubscription.CustomerId;
                        previousSubscription.PlanName = previousSubscription.PlanName;
                        previousSubscription.StartDate = previousSubscription.StartDate;
                        previousSubscription.EndDate = previousSubscription.EndDate;
                        previousSubscription.ActiveEndDate = previousSubscription.ActiveEndDate;
                        previousSubscription.CurrentBalanceUnits = 0;
                        previousSubscription.ProductName=previousSubscription.ProductName;
                        // Archive and deactivate previous subscription
                        previousSubscription.IsArchive = true;
                        previousSubscription.IsActive = false;
                        subscriptionHandler.Update(uow, new SaveRequest<SubscriptionRow> { Entity = previousSubscription });

                        var UpdateRegularAudit = _subscriptionService.InsertSubscriptionWithAudit(previousSubscription, uow);
                        _subscriptionService.SaveSubscriptionAudit(uow, UpdateRegularAudit);
                    }

                    // Create a new subscription for the regular plan
                    regularSubscription = new SubscriptionRow
                    {
                        ApplicationTenantId = tenantId,
                        PlanId = planId,
                        CustomerId = customerId,
                        PlanName = plan.PlanName,
                    ProductName = plan.ProductName,
                        StartDate = request.Entity.RechargeDate,
                        EndDate = CalculateEndDate(request.Entity.RechargeDate, plan.Frequency),
                        ActiveEndDate = CalculateActiveEndDate(request.Entity.RechargeDate, plan.Frequency),
                        TotalUnits = plan.Units,
                        CurrentBalanceUnits = plan.Units,
                        IsActive = false, // New regular subscription is inactive initially
                        IsArchive = false // New regular subscription is not archived
                    };

                    subscriptionHandler.Create(uow, new SaveRequest<SubscriptionRow> { Entity = regularSubscription });
                    var insertRegularAudit = _subscriptionService.InsertSubscriptionWithAudit(regularSubscription, uow);
                    _subscriptionService.SaveSubscriptionAudit(uow, insertRegularAudit);
                }

                // Step 4: Handle Top-Up Plan
                // Step 4: Handle Top-Up Plan
                else if (plan.Type.Equals("topup", StringComparison.OrdinalIgnoreCase))
                {
                    if (previousSubscription1 != null)
                    {
                        // Create a new top-up subscription record
                        // Create a new top-up subscription record
                        var topUpSubscription = new SubscriptionRow
                        {
                            ApplicationTenantId = tenantId,
                            PlanId = previousSubscription1.PlanId,
                            CustomerId=previousSubscription1.CustomerId,
                            PlanName = previousSubscription1.PlanName,
                         ProductName=previousSubscription1.ProductName,
                            StartDate =previousSubscription1.StartDate,
                            EndDate = previousSubscription1.EndDate,
                            ActiveEndDate = previousSubscription1.ActiveEndDate,
                            IsActive = true,
                            IsArchive = false
                        };

                        // Archive and deactivate the previous subscription
                        previousSubscription1.IsArchive = true;
                        previousSubscription1.IsActive = false;

                        // Save the top-up subscription audit (optional if your logic requires it before update)
                        var topupAudit = _subscriptionService.InsertSubscriptionWithAudit(previousSubscription1, uow);
                        _subscriptionService.SaveSubscriptionAudit(uow, topupAudit);

                        // Save updated previous subscription
                        subscriptionHandler.Update(uow, new SaveRequest<SubscriptionRow> { Entity = previousSubscription1 });

                        // Save audit for updated previous subscription
                        var updatedPreviousSubscriptionAudit = _subscriptionService.InsertSubscriptionWithAudit(previousSubscription1, uow);
                        _subscriptionService.SaveSubscriptionAudit(uow, updatedPreviousSubscriptionAudit);

                        // Add units from previous subscription's balance
                        topUpSubscription.TotalUnits = plan.Units + (previousSubscription1.CurrentBalanceUnits ?? 0);
                        topUpSubscription.CurrentBalanceUnits = topUpSubscription.TotalUnits;

                        // Create the top-up subscription
                        subscriptionHandler.Create(uow, new SaveRequest<SubscriptionRow> { Entity = topUpSubscription });

                        //subscriptionHandler.Update(uow, new SaveRequest<SubscriptionRow> { Entity = topUpSubscription });


                    }
                    else
                    {
                        throw new ValidationError("No active subscription found for this tenant. Cannot apply top-up.");
                    }
                }

                var subscription = regularSubscription ?? previousSubscription ?? previousSubscription1;

                if (subscription != null && subscription.EndDate != null)
                {

                    var ApplicationTenant = uow.Connection.TryFirst<TenantRow>(q =>
    q.Select(
        TenantRow.Fields.TenantId,
        TenantRow.Fields.TenantName,
        TenantRow.Fields.Email,
        TenantRow.Fields.Phone
    )
    .Where(TenantRow.Fields.TenantId == tenantId.Value));




                    var loggedTenantUser = uow.Connection.TryFirst<TenantRow>(q =>
                        q.Select(
                            TenantRow.Fields.TenantId,
                            TenantRow.Fields.TenantName,
                            TenantRow.Fields.Email,
                            TenantRow.Fields.Phone
                        )
                        .Where(TenantRow.Fields.TenantId == loggedTenant));


                    var customer = uow.Connection.TryFirst<CustomerRow>(q =>
     q.Select(CustomerRow.Fields.Id,
      CustomerRow.Fields.Email,
      CustomerRow.Fields.Name,

                            CustomerRow.Fields.Phone)
      .Where(CustomerRow.Fields.Id == customerId.Value));
                    var endDate = subscription.EndDate.Value;
                    var (reminder1Date, reminder2Date) = GetReminderDates(endDate, plan.Frequency);

                    var whatsappTemplate = uow.Connection.TryFirst<WhatsAppRow>(q =>
    q.Select(
        WhatsAppRow.Fields.Id,
        WhatsAppRow.Fields.TemplateName,
        WhatsAppRow.Fields.BroadcastName,
        WhatsAppRow.Fields.Url
    )
                    .Where(WhatsAppRow.Fields.TenantId == loggedTenant)
                    .Where(WhatsAppRow.Fields.IsActive == 1)
                    .Where(WhatsAppRow.Fields.BroadcastName == CommonConstant.SubscrtionTemplateName)); // 👈 dynamic based on use case

                    var template = uow.Connection.TryFirst<TemplateRow>(q =>
        q.Select(TemplateRow.Fields.Body,
        TemplateRow.Fields.TemplateName)
        .Where(TemplateRow.Fields.TemplateName == CommonConstant.SubscrtionTemplateName)
        .Where(TemplateRow.Fields.TenantId == loggedTenant));


                    var messageBodyTemplate = template?.Body;

                    string formattedMessageBody = string.Format(
                        messageBodyTemplate,
                        customer.Name,
                        plan.PlanName,
                        endDate.ToString("dd-MMM-yyyy"));


                    var dueDateReminder = new DueDateReminderRow
                    {
                        CustomerId = request.Entity.CustomerId,
                        
                        PlanId = plan.Id,
                        ConsentDueDate = endDate,
                        WhatsAppId = whatsappTemplate.Id,
                        Remainder1 = reminder1Date < DateTime.Now ? (DateTime?)null : reminder1Date,
                        Remainder2 = reminder2Date < DateTime.Now ? (DateTime?)null : reminder2Date,
                        SendRemainderOnWhatsapp = true,
                        SendRemainderOnEmail = true,
                        IsEnable = true,
                        IsActionComplete = false,
                        Subject = template.TemplateName,
                        MessageBody = formattedMessageBody,
                        TenantEmail = loggedTenantUser.Email,
                        ToEmail = customer.Email,
                        ReminderInCC = loggedInUserEmail,
                        TenantPhone = loggedTenantUser.Phone,
                        CustomerPhone = customer.Phone,
                        CustomerName = customer.Name
                    };

                    reminderHandler.Create(uow, new SaveRequest<DueDateReminderRow> { Entity = dueDateReminder });
                    


                }
                // Step 5: Create TenantUnitTransaction record
                var tenantUnitTransaction = new TenantUnitTransactionRow
                {
                    TenantId = tenantId,
                    SubscriptionId = regularSubscription?.Id ?? previousSubscription?.Id ?? previousSubscription1.Id,
                    Units = plan.Units,
                    ReferenceId = planId,
                    Remark = $"Plan Applied: {plan.PlanName}"
                };

                tenantUnitTransactionHandler.Create(uow, new SaveRequest<TenantUnitTransactionRow> { Entity = tenantUnitTransaction });

                return addBalanceResponse;
            }
            catch (ValidationError ex)
            {
                throw new ValidationError($"Validation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }
        }
        private DateTime CalculateEndDate(DateTime? rechargeDate, string frequency)
        {
            if (rechargeDate == null)
                throw new ArgumentNullException(nameof(rechargeDate));

            var startDate = rechargeDate.Value;
            DateTime endDate;

            switch (frequency.ToLower())
            {
                case "monthly":
                    endDate = startDate.AddMonths(1).AddDays(-1);
                    break;
                case "quarterly":
                    endDate = startDate.AddMonths(3).AddDays(-1);
                    break;
                case "yearly":
                    endDate = startDate.AddYears(1).AddDays(-1);
                    break;
                default:
                    throw new ArgumentException("Invalid frequency", nameof(frequency));
            }

            // Ensure end date is less than 1 year from the start date
            if (endDate.Year - startDate.Year > 1 ||
                (endDate.Year - startDate.Year == 1 && endDate.Month > startDate.Month))
            {
                endDate = new DateTime(startDate.Year + 1, startDate.Month, startDate.Day).AddDays(-1);
            }

            return endDate;
        }
        private (DateTime? reminder1, DateTime? reminder2) GetReminderDates(DateTime endDate, string frequency)
        {
            DateTime? r1 = null, r2 = null;
            var now = DateTime.Now;

            switch (frequency.ToLower())
            {
                case "monthly":
                    r1 = endDate.AddDays(-7);
                    r2 = endDate.AddDays(-2);
                    break;
                case "quarterly":
                    r1 = endDate.AddDays(-15);
                    r2 = endDate.AddDays(-7);
                    break;
                case "yearly":
                    r1 = endDate.AddMonths(-1);
                    r2 = endDate.AddDays(-15);
                    break;
                default:
                    throw new ArgumentException("Unknown frequency: " + frequency);
            }

            if (r1 <= now) r1 = null;
            if (r2 <= now) r2 = null;

            return (r1, r2);
        }

        private DateTime CalculateActiveEndDate(DateTime? rechargeDate, string frequency)
        {
            var endDate = CalculateEndDate(rechargeDate, frequency);
            return endDate.AddMonths(1); // Active for 1 month after end date
        }

        // Fetch Plan details (you can adjust this as needed)
        private PlanSettingRow GetPlanDetails(IUnitOfWork uow, int planId)
        {
            var plan = uow.Connection.TryFirst<PlanSettingRow>(q => q
                .Select(PlanSettingRow.Fields.Id, PlanSettingRow.Fields.PlanName, PlanSettingRow.Fields.Cost, PlanSettingRow.Fields.Units,PlanSettingRow.Fields.Frequency,
                PlanSettingRow.Fields.Type,PlanSettingRow.Fields.ProductId, PlanSettingRow.Fields.ProductName)
        .Where(PlanSettingRow.Fields.Id == planId));

            if (plan == null)
                throw new Exception("Plan not found.");

            return plan;
        }
        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IAddBalanceSaveHandler handler)
        {
            var response = handler.Update(uow, request);
           // var addBalanceResponse = handler.Create(uow, request);
            var tenantId = request.Entity.TenantId;
            var planId = request.Entity.PlanId;
            if (!tenantId.HasValue || !planId.HasValue)
            {
                throw new ArgumentException("TenantId and PlanId must not be null.");
            }
            var plan = GetPlanDetails(uow, (int)planId);
            var subscription = uow.Connection.Query<SubscriptionRow>(
      @"SELECT TOP 1 Id, ApplicationTenantId, PlanId,StartDate, EndDate, ActiveEndDate, 
        TotalUnits, CurrentBalanceUnits, IsActive, IsArchive 
      FROM Subscription 
      WHERE ApplicationTenantId = @TenantId AND IsActive = 1 AND PlanId = @PlanId",
      new { TenantId = tenantId.Value, PlanId = planId.Value }).FirstOrDefault();

            if (subscription == null)
            {
                throw new ArgumentException("No active subscription found for the provided TenantId and PlanId.");
            }

            // Step 3: Create the audit record for the subscription update
            var subscriptionAudit = _subscriptionService.UpdateSubscriptionWithAudit(subscription,uow);

            // Step 4: Save the audit record
            _subscriptionService.SaveSubscriptionAudit(uow, subscriptionAudit);

            // Return the response after the update and audit
            return response;
        }
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IAddBalanceDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }
      
        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
     [FromServices] IAddBalanceRetrieveHandler handler, [FromServices] IUserRetrieveService userRetrieveService)
        {
            return handler.Retrieve(connection, request);

           
        }


        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IAddBalanceListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IAddBalanceListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.AddBalanceColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "AddBalanceList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}