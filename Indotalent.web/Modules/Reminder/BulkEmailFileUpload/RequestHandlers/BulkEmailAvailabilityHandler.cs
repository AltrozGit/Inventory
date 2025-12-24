using FluentMigrator.Runner.Processors.Firebird;
using Indotalent.Administration;
using Indotalent.Web.Common;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using static Indotalent.Web.Modules.Reminder.BulkEmailSender.RequestHandlers.BulkEmailAvailabilityHandler;

namespace Indotalent.Web.Modules.Reminder.BulkEmailSender.RequestHandlers
{
    public class BulkEmailAvailabilityHandler : ServiceRequest
    {
        public class BulkEmailAvailabilityRequest : ServiceRequest
        {
        }

        public class BulkEmailAvailabilityResponse : ServiceResponse
        {
            public bool IsBulkEmailAvailable { get; set; }
        }

        public interface IBulkEmailAvailabilityHandler : IRequestHandler
        {
            BulkEmailAvailabilityResponse IsBulkEmailAvailable(IDbConnection connection, BulkEmailAvailabilityRequest request);
        }

        public class Handler : IBulkEmailAvailabilityHandler
        {
            protected IUserAccessor UserAccessor { get; }
            private IUserRetrieveService UserRetriever { get; }

            public Handler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
            {
                UserAccessor = userAccessor;
                UserRetriever = userRetriever;
            }

            public BulkEmailAvailabilityResponse IsBulkEmailAvailable(IDbConnection connection, BulkEmailAvailabilityRequest request)
            {
                var user = UserAccessor.User?.GetUserDefinition(UserRetriever) as UserDefinition;
                var tenant = connection.First<TenantRow>(x => x.SelectTableFields().Where(TenantRow.Fields.TenantId == user.TenantId));
                var tenantId = tenant.TenantId;

                var BulkEmailRow = DbHelper.GetEmailFileUpload((int)tenantId);

                var result = new BulkEmailAvailabilityResponse();

                if (BulkEmailRow != null)
                {
                    result.IsBulkEmailAvailable = true;
                }
                else
                {
                    result.IsBulkEmailAvailable = false;
                }


                return result;
            }
        }
    }
}
