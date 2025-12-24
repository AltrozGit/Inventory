using Indotalent.Reminder;
using Serenity.Data;

namespace Indotalent.Web.Common
{
    internal static class DbHelper
    {
        internal static BulkEmailFileUploadRow GetEmailFileUpload(int Id)
        {
            using (var connection = AppStatics.SqlConnections.NewFor<BulkEmailFileUploadRow>())
            {
                return connection.ById<BulkEmailFileUploadRow>(Id);
            }
        }
        internal static BulkEmailFileUploadRow GetTimeSheetUpload(int tenantId)
        {
            using (var connection = AppStatics.SqlConnections.NewFor<BulkEmailFileUploadRow>())
            {
                var rowFields = BulkEmailFileUploadRow.Fields;

                return connection.TryFirst<BulkEmailFileUploadRow>(row => row.SelectTableFields()
                .Where(
                rowFields.TenantId == tenantId));
            }
        }
    }
}
