
using Serenity.ComponentModel;
using System.ComponentModel;

namespace Indotalent.Administration
{
    [NestedPermissionKeys]
    [DisplayName("Administration")]
    public class PermissionKeys
    {
        

        [Description("User, Role Management and Permissions")]
        public const string Security = "Administration:Security";

        [Description("Languages and Translations")]
        public const string Translation = "Administration:Translation";

        [Description("Multi tenant management")]
        public const string Tenant = "Administration:Tenant";
        [Description("Modify tenant management")]
        public const string ModifyTenant = "Administration:ModifyTenant";
        [Description("Approval management")]
		public const string Approvalmanagement = "Administration:Approvalmanagement";

		[Description("ProjectApproval management")]
		public const string ProjectApprovalmanagement = "Administration:ProjectApprovalmanagement";
        [Description("Plan Setting management")]
        public const string PlanSetting = "Reminder:PlanSetting";
    }
}
