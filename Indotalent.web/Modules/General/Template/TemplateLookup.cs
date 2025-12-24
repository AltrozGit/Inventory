using Indotalent.Administration.Entities;
using Indotalent.Projects;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Web;
using Indotalent.Administration.Lookups;
using Indotalent.Merchandise;
using Indotalent.General;

namespace Indotalent.Web.Modules.General.Template
{
	[LookupScript]
	public sealed class TemplateLookup : RowLookupScript<TemplateRow>
	{
		public TemplateLookup(ISqlConnections sqlConnections)
			: base(sqlConnections)
		{
			//    IdField = ProjectRow.Fields.Id.PropertyName;
			//    Permission = "*";
		}
	}
}
