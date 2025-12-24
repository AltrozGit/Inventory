using Dapper;
using Indotalent.Administration;
using Indotalent.Administration.Entities;
using Indotalent.Inventory;
using Indotalent.Sales;
using Indotalent.Settings;
using Indotalent.Web.Common;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using static MVC.Views.Settings;

namespace Indotalent
{
    public class GetNextNumberRequest : ServiceRequest
    {
        public string Prefix { get; set; }
        public int Length { get; set; }
    }
    public class GetNextNumberResponse : ServiceResponse
    {
        public long Number { get; set; }
        public string Serial { get; set; }
    }


    public class MultiTenantHelper
    {

       
        public static GetNextNumberResponse GetNextNumber(IDbConnection connection,
                                                          GetNextNumberRequest request, 
                                                          Field field,
                                                          int? tenantId)
        {
            var prefix = request.Prefix ?? "";

            var max = connection.Query<string>(new SqlQuery()
                .From(field.Fields)
                .Select(Sql.Max(field.Expression))
                .Where("TenantId = " + tenantId)
                .Where(
                    field.StartsWith(prefix) &&
                    field >= prefix.PadRight(request.Length, '0') &&
                    field <= prefix.PadRight(request.Length, '9')))
                .FirstOrDefault();

            var response = new GetNextNumberResponse
            {
                Number = max == null ||
                !long.TryParse(max[prefix.Length..], out long l) ? 1 : l + 1
            };

            if (!(request.Length > prefix.Length))
            {
                request.Length = prefix.Length + response.Number.ToString(CultureInfo.InvariantCulture).Length + 3;
            }

            response.Serial = prefix + response.Number.ToString(CultureInfo.InvariantCulture)
                .PadLeft(request.Length - prefix.Length, '0');

            return response;
        }
        public static int CreateTenant(IDbConnection connection, string name, string currency, int maxUser)
        {
            var tenantId = (int)connection.InsertAndGetID(new TenantRow
            {
                TenantName = name,
                Currency = currency,
                MaximumUser = maxUser,
                ProductNumberPrefix = "ART",
                ProductNumberUseDate = false,
                ProductNumberLength = 16,
                CustomerNumberPrefix = "CST",
                CustomerNumberUseDate = true,
                CustomerNumberLength = 16,
                SalesNumberPrefix = "SO",
                SalesNumberUseDate = true,
                SalesNumberLength = 16,
                InvoiceNumberPrefix = "INV",
                InvoiceNumberUseDate = true,
                InvoiceNumberLength = 16,
                InvoicePaymentNumberPrefix = "IVPY",
                InvoicePaymentNumberUseDate = true,
                InvoicePaymentNumberLength = 16,
                VendorNumberPrefix = "VND",
                VendorNumberUseDate = true,
                VendorNumberLength = 16,
                PurchaseNumberPrefix = "PO",
                PurchaseNumberUseDate = true,
                PurchaseNumberLength = 16,
                BillNumberPrefix = "BLL",
                BillNumberUseDate = true,
                BillNumberLength = 16,
                QuotationNumberPrefix = "QUOT",
                QuotationNumberUseDate = true,
                QuotationNumberLength = 16,
                BillPaymentNumberPrefix = "BLPY",
                BillPaymentNumberUseDate = true,
                BillPaymentNumberLength = 16,
                SalesDeliveryNumberPrefix = "DO",
                SalesDeliveryNumberUseDate = true,
                SalesDeliveryNumberLength = 16,
                SalesReturnNumberPrefix = "DORN",
                SalesReturnNumberUseDate = true,
                SalesReturnNumberLength = 16,
                PurchaseReceiptNumberPrefix = "GR",
                PurchaseReceiptNumberUseDate = true,
                PurchaseReceiptNumberLength = 16,
                PurchaseReturnNumberPrefix = "GRRN",
                PurchaseReturnNumberUseDate = true,
                PurchaseReturnNumberLength = 16,
                PositiveAdjustmentNumberPrefix = "AJPF",
                PositiveAdjustmentNumberUseDate = true,
                PositiveAdjustmentNumberLength = 16,
                NegativeAdjustmentNumberPrefix = "AJNF",
                NegativeAdjustmentNumberUseDate = true,
                NegativeAdjustmentNumberLength = 16,
                TransferOrderNumberPrefix = "TO",
                TransferOrderNumberUseDate = true,
                TransferOrderNumberLength = 16,
                MaterialRequestNumberPrefix = "MRPF",
                MaterialRequestNumberUseDate = true,
                MaterialRequestNumberLength = 16,
                MaterialIssueNumberPrefix = "MIPF",
                MaterialIssueNumberUseDate = true,
                MaterialIssueNumberLength = 16,
                MaterialReturnNumberPrefix = "MTRN",
                MaterialReturnNumberUseDate = true,
                MaterialReturnNumberLength = 16,
            });

            return tenantId;
        }
        public static void GenerateDefaultBusinessEntity(IDbConnection connection, int? tenantId, string name)
        {
            InsertTenantUser(connection, Convert.ToInt32(tenantId), name);
            GenerateDefaultTemplate(connection, Convert.ToInt32(tenantId));
        }
        public static void GenerateDefaultTemplate(IDbConnection dbConnection, int? tenantId)
        {
            var connection = dbConnection;


            if (tenantId.HasValue)
            {
                // Define the parameters to be passed to the stored procedure
                var parameters = new DynamicParameters();
                parameters.Add("tenantId", tenantId.Value);
                // parameters.Add("userId", tenantAdminId);  // Assuming tenantAdminId is the userId in the stored procedure

                // Execute the stored procedure
                //var storedData=dbConnection.ExecuteScalar("CreateCommunityUserConfiguration", parameters, commandType: CommandType.StoredProcedure);//error at this code
                var storedData = Dapper.SqlMapper.Execute(dbConnection, "InsertTemplate", parameters, commandType: CommandType.StoredProcedure);

            }


        }
        private static void InsertTenantUser(IDbConnection connection, int tenantId, string name)
        {

            var userid = (int)connection.InsertAndGetID(new UserRow
            {
                Username = name + "admin",
                DisplayName = name + "admin",
                Email = name + "@gmail.com",
                Source = "site",
                PasswordHash = "",
                PasswordSalt = "",
                IsActive = 1,
                IsTenantAdmin = true,
                InsertUserId = 1,
                TenantId = tenantId,
                InsertDate = DateTime.Now

            });

            InsertUserPermission(connection, userid);
        }
        private static void InsertUserPermission(IDbConnection connection, int userId)
        {
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Administration:General",
                Granted = true,

            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Administration:Approvalmanagement",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Administration:ModifyTenant",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Administration:ProjectApprovalmanagement",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Administration:Security",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Bills:Bill",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Bills:BillDetail",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Bills:BillPayment",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "General:Action",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "General:ActionNotification",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "General:Template",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "InternalCode:HSN",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "InternalCode:SAC",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Inventory:Location",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Inventory:Movement",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Inventory:NegativeAdjustment",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Inventory:PositiveAdjustment",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Inventory:Shipper",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Inventory:Stock",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Inventory:TransferOrder",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Inventory:Warehouse",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Material:Issue",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Material:IssueDetail",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Material:MaterialRequestStatus",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Material:MaterialRequestTracking",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Material:Request",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Material:RequestDetail",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Material:StatusMaster",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Merchandise:Brand",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Merchandise:Category",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Merchandise:Colour",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Merchandise:Configuration",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Merchandise:Flavour",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Merchandise:HSN",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Merchandise:Product",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Merchandise:SAC",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Merchandise:Size",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Merchandise:Uom",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Notifications:EmailSendingSummary",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Projects:Expense",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Projects:Project",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Projects:ProjectExpense",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Projects:ProjectFund",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Projects:ProjectMaterialRequest",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Projects:ProjectMaterialRequestDetail",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Projects:Quotation",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Projects:QuotationDetail",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Purchase:PurchaseOrder",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Purchase:PurchaseReceipt",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Purchase:PurchaseReceiptDetail",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Purchase:PurchaseReturn",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Purchase:PurchaseReturnDetail",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Purchase:Vendor",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Reminder:AddBalance",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Reminder:BulkEmailFileUpload",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Reminder:BulkEmailSenderStatus",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Reminder:DueDateReminder",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Reminder:EmailNotification",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Reminder:Plan",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Reminder:PlanSetting",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Reminder:SmtpConfiguration",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Reminder:Subscription",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Reminder:SubscriptionAudit",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Reminder:TenantUnitTransaction",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Sales:Customer",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Sales:Invoice",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Sales:InvoicePayment",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Sales:SalesChannel",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Sales:SalesDelivery",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Sales:SalesDeliveryDetail",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Sales:SalesOrder",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Sales:SalesReturn",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Sales:SalesReturnDetail",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Settings:CashBank",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Settings:Country",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Settings:MyCompany",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Settings:PurchaseTax",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Settings:SalesTax",
                Granted = true,
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = userId,
                PermissionKey = "Settings:State",
                Granted = true,
            });


        }


        public static void GenerateDefaultBusinessEntity(IDbConnection dbConnection, int? tenantId)
        {
            var connection = dbConnection;

            //purchase tax
            connection.Insert(new PurchaseTaxRow
            {
                Name = "NOTAX",
                TaxRatePercentage = 0,
                TenantId = tenantId
            });

            //sales tax
            connection.Insert(new SalesTaxRow
            {
                Name = "NOTAX",
                TaxRatePercentage = 0,
                TenantId = tenantId
            });

            //sales channel
            connection.Insert(new SalesChannelRow
            {
                Name = "B2B",
                TenantId = tenantId
            });
            connection.Insert(new SalesChannelRow
            {
                Name = "ECommerce",
                TenantId = tenantId
            });
            connection.Insert(new SalesChannelRow
            {
                Name = "Marketplace",
                TenantId = tenantId
            });

            //cash bank
            connection.Insert(new CashBankRow
            {
                Name = "Default Bank",
                AccountNumber = "111-222-333",
                TenantId = tenantId
            });

            //shipper
            connection.Insert(new ShipperRow
            {
                Name = "Internal",
                TenantId = tenantId
            });

            connection.Insert(new ShipperRow
            {
                Name = "FedEx",
                TenantId = tenantId
            });

            connection.Insert(new ShipperRow
            {
                Name = "DHL",
                TenantId = tenantId
            });

            //warehouse
            connection.Insert(new WarehouseRow
            {
                Name = "Main WH",
                TenantId = tenantId
            });

            ////country
            //connection.Insert(new CountryRow
            //{
            //    Name = "India",
            //    CountryCode = "+91"
            //});

            ////State
            //connection.Insert(new StateRow
            //{
            //    Name = "Andhra Pradesh",

            //    StateCode = "AP"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Arunachal Pradesh",
            //    StateCode = "AR"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Assam",
            //    StateCode = "AS"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Bihar",
            //    StateCode = "BR"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Chhattisgarh",
            //    StateCode = "CG"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Goa",
            //    StateCode = "GA"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Gujarat",
            //    StateCode = "GJ"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Haryana",
            //    StateCode = "HR"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Himachal Pradesh",
            //    StateCode = "HP"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Jharkhand",
            //    StateCode = "JH"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Karnataka",
            //    StateCode = "KA"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Kerala",
            //    StateCode = "KL"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Madhya Pradesh",
            //    StateCode = "MP"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Maharashtra",
            //    StateCode = "MH"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Manipur",
            //    StateCode = "MN"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Meghalaya",
            //    StateCode = "ML"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Mizoram",
            //    StateCode = "MZ"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Nagaland",
            //    StateCode = "NL"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Odisha",
            //    StateCode = "OR"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Punjab",
            //    StateCode = "PB"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Rajasthan",
            //    StateCode = "RJ"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Sikkim",
            //    StateCode = "SK"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Tamil Nadu",
            //    StateCode = "TN"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Telangana",
            //    StateCode = "TG"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Tripura",
            //    StateCode = "TR"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Uttar Pradesh",
            //    StateCode = "UP"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Uttarakhand",
            //    StateCode = "UK"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "West Bengal",
            //    StateCode = "WB"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Andaman and Nicobar Islands",
            //    StateCode = "AN"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Chandigarh",
            //    StateCode = "CH"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Dadra and Nagar Haveli and Daman and Diu",
            //    StateCode = "DN"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Delhi",
            //    StateCode = "DL"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Jammu and Kashmir",
            //    StateCode = "JK"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Ladakh",
            //    StateCode = "LA"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "DelPuducherryhi",
            //    StateCode = "PY"

            //});
            //connection.Insert(new StateRow
            //{
            //    Name = "Lakshadweep",
            //    StateCode = "LD"

            //});

        }

        

        //private static void InsertCountry(IDbConnection connection, int tenantId)
        //{
        //    connection.Insert(new CountryRow
        //    {
        //        Name = "India",
        //        CountryCode="+91"
        //    });
        //}
        //private static void InsertState(IDbConnection connection, int tenantId)
        //{
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Andhra Pradesh",
                
        //        StateCode ="AP"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Arunachal Pradesh",
        //        StateCode = "AR"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Assam",
        //        StateCode = "AS"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Bihar",
        //        StateCode = "BR"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Chhattisgarh",
        //        StateCode = "CG"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Goa",
        //        StateCode = "GA"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Gujarat",
        //        StateCode = "GJ"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Haryana",
        //        StateCode = "HR"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Himachal Pradesh",
        //        StateCode = "HP"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Jharkhand",
        //        StateCode = "JH"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Karnataka",
        //        StateCode = "KA"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Kerala",
        //        StateCode = "KL"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Madhya Pradesh",
        //        StateCode = "MP"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Maharashtra",
        //        StateCode = "MH"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Manipur",
        //        StateCode = "MN"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Meghalaya",
        //        StateCode = "ML"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Mizoram",
        //        StateCode = "MZ"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Nagaland",
        //        StateCode = "NL"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Odisha",
        //        StateCode = "OR"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Punjab",
        //        StateCode = "PB"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Rajasthan",
        //        StateCode = "RJ"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Sikkim",
        //        StateCode = "SK"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Tamil Nadu",
        //        StateCode = "TN"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Telangana",
        //        StateCode = "TG"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Tripura",
        //        StateCode = "TR"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Uttar Pradesh",
        //        StateCode = "UP"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Uttarakhand",
        //        StateCode = "UK"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "West Bengal",
        //        StateCode = "WB"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Andaman and Nicobar Islands",
        //        StateCode = "AN"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Chandigarh",
        //        StateCode = "CH"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Dadra and Nagar Haveli and Daman and Diu",
        //        StateCode = "DN"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Delhi",
        //        StateCode = "DL"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Jammu and Kashmir",
        //        StateCode = "JK"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Ladakh",
        //        StateCode = "LA"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "DelPuducherryhi",
        //        StateCode = "PY"

        //    });
        //    connection.Insert(new StateRow
        //    {
        //        Name = "Lakshadweep",
        //        StateCode = "LD"

        //    });

        //}
        public static void GenerateDefaultTenantAdminPermission(int tenantAdminId, IDbConnection dbConnection)
        {
            var connection = dbConnection;

            //administration
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Administration:Security",
                Granted = true
            });

            //settings
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Settings:MyCompany",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Settings:CashBank",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Settings:PurchaseTax",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Settings:SalesTax",
                Granted = true
            });

            //merchandise
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Merchandise:Uom",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Merchandise:Size",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Merchandise:Colour",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Merchandise:Flavour",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Merchandise:Brand",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Merchandise:Category",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Merchandise:Product",
                Granted = true
            });

            //purchase
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Purchase:Vendor",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Purchase:PurchaseOrder",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Purchase:Bill",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Purchase:BillPayment",
                Granted = true
            });

            //sales
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Sales:SalesChannel",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Sales:Customer",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Sales:SalesOrder",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Sales:Invoice",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Sales:InvoicePayment",
                Granted = true
            });

            //inventory
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Inventory:Shipper",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Inventory:Location",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Inventory:Warehouse",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Inventory:SalesDelivery",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Inventory:SalesReturn",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Inventory:PurchaseReceipt",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Inventory:PurchaseReturn",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Inventory:PositiveAdjustment",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Inventory:NegativeAdjustment",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Inventory:TransferOrder",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Inventory:Stock",
                Granted = true
            });
            connection.Insert(new UserPermissionRow
            {
                UserId = tenantAdminId,
                PermissionKey = "Inventory:Movement",
                Granted = true
            });

        }
    }
}
