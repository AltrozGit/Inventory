using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
	[Migration(20250130172055)]
	public class DefaultDB_20250130_172055_Indotalent_AlterVendorWithPaymentTermId : AutoReversingMigration
	{
		public override void Up()
		{

			Alter.Table("Vendor")
			   .AddColumn("PaymentTermId").AsInt32().Nullable()
			 .ForeignKey("FK_Vendor_PaymentTermId", "dbo", "PaymentTerm", "Id");
			 
		}

	}
}