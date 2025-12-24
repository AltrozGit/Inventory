using System.ComponentModel;

namespace Indotalent.Web.Modules.Projects.ProjectMaterialRequest
{
	public enum RequestStatus
	{
		[Description("Pending")]
		Pending = 1,
		[Description("Approved")]
		Approved = 2,
		[Description("Rejected")]
		Rejected = 3
	}
}
