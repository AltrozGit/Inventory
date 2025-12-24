using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = Indotalent.Reminder.PlanRow;

namespace Indotalent.Reminder.Endpoints
{
    [Route("Services/Reminder/Plan/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class PlanController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
    [FromServices] IPlanSaveHandler handler,
    [FromServices] IAddBalanceSaveHandler addBalanceSaveHandler, [FromServices] ISubscriptionSaveHandler subscriptionSaveHandler,
    [FromServices] ITenantUnitTransactionSaveHandler tenantUnitTransactionSaveHandler)  // Inject AddBalance handler
        {
            // Create the Plan record
            return handler.Create(uow, request);

    //        // After creating the Plan, add or update the AddBalance table
    //        var planId = request.Entity.Id; // Get the Plan ID after creation
    //        var tenantId=request.Entity.TenantId;
    //        if (request.Entity.IsActive == true)
    //        {
    //            DateTime endDate = DateTime.Now;
    //            DateTime activeEndDate = DateTime.Now;

    //            switch (request.Entity.Frequency?.ToLower()) // Assuming Frequency is stored as a string like "yearly", "monthly", etc.
    //            {
    //                case "yearly":
    //                    endDate = DateTime.Now.AddYears(1);
    //                    activeEndDate = endDate.AddMonths(1);
    //                    break;
    //                case "monthly":
    //                    endDate = DateTime.Now.AddMonths(1);
    //                    activeEndDate = endDate.AddMonths(1);
    //                    break;
    //                case "weekly":
    //                    endDate = DateTime.Now.AddDays(7);
    //                    activeEndDate = endDate.AddMonths(1);
    //                    break;
    //                default:
    //                    endDate = DateTime.Now.AddYears(1); // Default fallback
    //                    activeEndDate = endDate.AddMonths(1);
    //                    break;
    //            }

    //            var addBalanceRequest = new SaveRequest<AddBalanceRow>
    //            {
    //                Entity = new AddBalanceRow
    //                {
    //                    TenantId = tenantId,   // Use the TenantId from Plan
    //                    PlanId = planId, 
    //                    PlanName=request.Entity.PlanName,// Set the newly created PlanId
    //                    RechargeDate = DateTime.Now,          // You can adjust this as per your business logic
    //                    ValidThrough = null,  // Example logic for ValidThrough
    //                }
    //            };
    //            addBalanceSaveHandler.Create(uow, addBalanceRequest);
    //            var subscriptionRequest = new SaveRequest<SubscriptionRow>
    //            {
    //                Entity = new SubscriptionRow
    //                {
    //                    TenantId = tenantId,   // Use the TenantId from Plan
    //                    PlanId = planId,
    //                    PlanName = request.Entity.PlanName,
    //                    StartDate = DateTime.Now,
    //                    EndDate = endDate, // Example logic
    //                    IsActive = false,
    //                    ActiveEndDate =activeEndDate,
    //                    TotalUnits = request.Entity.Units, // Example logic
    //                    CurrentBalanceUnits = request.Entity.Units // Example logic
    //                }
    //            };
    //            var subscriptionResponse = subscriptionSaveHandler.Create(uow, subscriptionRequest);
    //            var tenantUnitTransactionRequest = new SaveRequest<TenantUnitTransactionRow>
    //            {
    //                Entity = new TenantUnitTransactionRow
    //                {
    //                    TenantId = tenantId,
    //                    SubscriptionId = subscriptionResponse.EntityId != null
    //? Convert.ToInt32(subscriptionResponse.EntityId)
    //: (int?)null,
            
    //                    Units = 0,
    //                    ReferenceId = planId,
    //                    Remark = $"Plan Created: {request.Entity.PlanName}",
    //                }
    //            };
    //            tenantUnitTransactionSaveHandler.Create(uow, tenantUnitTransactionRequest);

    //        }


    //        // Save to AddBalance

    //        return planResponse;  // Return the response from Plan creation
        }


        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
     [FromServices] IPlanSaveHandler handler,
     [FromServices] IAddBalanceSaveHandler addBalanceSaveHandler,
     [FromServices] ISubscriptionSaveHandler subscriptionSaveHandler,
     [FromServices] ITenantUnitTransactionSaveHandler tenantUnitTransactionSaveHandler) // Inject Subscription handler
        {
          return handler.Update(uow, request);

            // Get the Plan ID and Tenant ID
        //    var planId = request.Entity.Id;
        //    var tenantId = request.Entity.TenantId;

        //    // Check if the plan is active and requires updating the AddBalance table and Subscription
        //    if (request.Entity.IsActive == true)
        //    {
        //        // Query the existing AddBalance record
        //        var existingAddBalance = uow.Connection.TryById<AddBalanceRow>(planId);

        //        if (existingAddBalance != null)
        //        {
        //            // Update the existing AddBalance record
        //            var addBalanceRequest = new SaveRequest<AddBalanceRow>
        //            {
        //                Entity = new AddBalanceRow
        //                {
        //                    Id = existingAddBalance.Id,  // Use the existing AddBalance Id for update
        //                    TenantId = tenantId,        // Tenant ID
        //                    PlanId = planId,            // Plan ID
        //                    PlanName = request.Entity.PlanName,  // Updated Plan Name
        //                    RechargeDate = existingAddBalance.RechargeDate, // Keep the existing Recharge Date
        //                    ValidThrough = null         // Update as needed
        //                }
        //            };
        //            addBalanceSaveHandler.Update(uow, addBalanceRequest);
        //        }
        //        else
        //        {
        //            // Create a new AddBalance record if it doesn't exist
        //            var addBalanceRequest = new SaveRequest<AddBalanceRow>
        //            {
        //                Entity = new AddBalanceRow
        //                {
        //                    TenantId = tenantId,        // Tenant ID
        //                    PlanId = planId,            // Plan ID
        //                    PlanName = request.Entity.PlanName,  // Plan Name
        //                    RechargeDate = DateTime.Now, // Set Recharge Date
        //                    ValidThrough = null         // Set ValidThrough as needed
        //                }
        //            };
        //            addBalanceSaveHandler.Create(uow, addBalanceRequest);
        //        }

        //        // Update the Subscription table
        //        var existingSubscription = uow.Connection.TryFirst<SubscriptionRow>(
        //new Criteria(SubscriptionRow.Fields.PlanId) == (planId ?? 0));

        //        if (existingSubscription != null)
        //        {
        //            // Calculate new EndDate and ActiveEndDate based on frequency
        //            DateTime endDate = DateTime.Now;
        //            DateTime activeEndDate = DateTime.Now;

        //            switch (request.Entity.Frequency?.ToLower())
        //            {
        //                case "yearly":
        //                    endDate = DateTime.Now.AddYears(1);
        //                    activeEndDate = endDate.AddMonths(1);
        //                    break;
        //                case "monthly":
        //                    endDate = DateTime.Now.AddMonths(1);
        //                    activeEndDate = endDate.AddMonths(1);
        //                    break;
        //                case "weekly":
        //                    endDate = DateTime.Now.AddDays(7);
        //                    activeEndDate = endDate.AddMonths(1);
        //                    break;
        //                default:
        //                    endDate = DateTime.Now.AddYears(1); // Default fallback
        //                    activeEndDate = endDate.AddMonths(1);
        //                    break;
        //            }

        //            // Update existing Subscription record
        //            var subscriptionRequest = new SaveRequest<SubscriptionRow>
        //            {
        //                Entity = new SubscriptionRow
        //                {
        //                    Id = existingSubscription.Id, // Use the existing Subscription Id
        //                    TenantId = tenantId,
        //                    PlanId = planId,
        //                    PlanName = request.Entity.PlanName,
        //                    StartDate = existingSubscription.StartDate, // Keep existing start date
        //                    EndDate = endDate,
        //                    IsActive = request.Entity.IsActive,
        //                    ActiveEndDate = activeEndDate,
        //                    TotalUnits = request.Entity.Units, // Updated units
        //                    CurrentBalanceUnits = request.Entity.Units // Updated balance units
        //                }
        //            };
        //            subscriptionSaveHandler.Update(uow, subscriptionRequest);
        //        }
        //        else
        //        {
        //            // Create a new Subscription record if it doesn't exist
        //            var subscriptionRequest = new SaveRequest<SubscriptionRow>
        //            {
        //                Entity = new SubscriptionRow
        //                {
        //                    TenantId = tenantId,
        //                    PlanId = planId,
        //                    PlanName = request.Entity.PlanName,
        //                    StartDate = DateTime.Now,
        //                    EndDate = DateTime.Now.AddYears(1), // Example logic
        //                    IsActive = false,
        //                    ActiveEndDate = DateTime.Now.AddYears(1).AddMonths(1),
        //                    TotalUnits = request.Entity.Units, // Example logic
        //                    CurrentBalanceUnits = request.Entity.Units // Example logic
        //                }
        //            };
        //            subscriptionSaveHandler.Create(uow, subscriptionRequest);
        //            var tenantUnitTransactionRequest = new SaveRequest<TenantUnitTransactionRow>
        //            {
        //                Entity = new TenantUnitTransactionRow
        //                {
        //                    TenantId = tenantId,
        //                    SubscriptionId = existingSubscription.Id, // You may need to adjust the reference depending on your logic
        //                    Units = 0, // Adjust as necessary
        //                    ReferenceId = planId,
        //                    Remark = $"Plan Updated: {request.Entity.PlanName}",
        //                }
        //            };
        //            tenantUnitTransactionSaveHandler.Create(uow, tenantUnitTransactionRequest);
        //        }
        //    }

            //return planResponse; // Return the response from Plan update
        }


        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IPlanDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IPlanRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IPlanListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IPlanListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.PlanColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "PlanList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}