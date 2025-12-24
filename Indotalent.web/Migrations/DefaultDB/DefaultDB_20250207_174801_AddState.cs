using FluentMigrator;
using Serenity.Extensions;

namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250207174801)]
    public class DefaultDB_20250207_174801_AddState : AutoReversingMigration
    {
        public override void Up()
        {

            

            //// Inserting the states
            Insert.IntoTable("State").Row(new { Name = "Andhra Pradesh", CountryId = 1, StateCode = "AP" });
            Insert.IntoTable("State").Row(new { Name = "Arunachal Pradesh", CountryId = 1, StateCode = "AR" });
            Insert.IntoTable("State").Row(new { Name = "Assam", CountryId = 1, StateCode = "AS" });
            Insert.IntoTable("State").Row(new { Name = "Bihar", CountryId = 1, StateCode = "BR" });
            Insert.IntoTable("State").Row(new { Name = "Chhattisgarh", CountryId = 1, StateCode = "CG" });
            Insert.IntoTable("State").Row(new { Name = "Goa", CountryId = 1, StateCode = "GA" });
            Insert.IntoTable("State").Row(new { Name = "Gujarat", CountryId = 1, StateCode = "GJ" });
            Insert.IntoTable("State").Row(new { Name = "Haryana", CountryId = 1, StateCode = "HR" });
            Insert.IntoTable("State").Row(new { Name = "Himachal Pradesh", CountryId = 1, StateCode = "HP" });
            Insert.IntoTable("State").Row(new { Name = "Jharkhand", CountryId = 1, StateCode = "JH" });
            Insert.IntoTable("State").Row(new { Name = "Karnataka", CountryId = 1, StateCode = "KA" });
            Insert.IntoTable("State").Row(new { Name = "Kerala", CountryId = 1, StateCode = "KL" });
            Insert.IntoTable("State").Row(new { Name = "Madhya Pradesh", CountryId = 1, StateCode = "MP" });
            Insert.IntoTable("State").Row(new { Name = "Maharashtra", CountryId = 1, StateCode = "MH" });
            Insert.IntoTable("State").Row(new { Name = "Manipur", CountryId = 1, StateCode = "MN" });
            Insert.IntoTable("State").Row(new { Name = "Meghalaya", CountryId = 1, StateCode = "ML" });
            Insert.IntoTable("State").Row(new { Name = "Mizoram", CountryId = 1, StateCode = "MZ" });
            Insert.IntoTable("State").Row(new { Name = "Nagaland", CountryId = 1, StateCode = "NL" });
            Insert.IntoTable("State").Row(new { Name = "Odisha", CountryId = 1, StateCode = "OR" });
            Insert.IntoTable("State").Row(new { Name = "Punjab", CountryId = 1, StateCode = "PB" });
            Insert.IntoTable("State").Row(new { Name = "Rajasthan", CountryId = 1, StateCode = "RJ" });
            Insert.IntoTable("State").Row(new { Name = "Sikkim", CountryId = 1, StateCode = "SK" });
            Insert.IntoTable("State").Row(new { Name = "Tamil Nadu", CountryId = 1, StateCode = "TN" });
            Insert.IntoTable("State").Row(new { Name = "Telangana", CountryId = 1, StateCode = "TG" });
            Insert.IntoTable("State").Row(new { Name = "Tripura", CountryId = 1, StateCode = "TR" });
            Insert.IntoTable("State").Row(new { Name = "Uttar Pradesh", CountryId = 1, StateCode = "UP" });
            Insert.IntoTable("State").Row(new { Name = "Uttarakhand", CountryId = 1, StateCode = "UK" });
            Insert.IntoTable("State").Row(new { Name = "West Bengal", CountryId = 1, StateCode = "WB" });
            Insert.IntoTable("State").Row(new { Name = "Andaman and Nicobar Islands", CountryId = 1, StateCode = "AN" });
            Insert.IntoTable("State").Row(new { Name = "Chandigarh", CountryId = 1, StateCode = "CH" });
            Insert.IntoTable("State").Row(new { Name = "Dadra and Nagar Haveli and Daman and Diu", CountryId = 1, StateCode = "DN" });
            Insert.IntoTable("State").Row(new { Name = "Delhi", CountryId = 1, StateCode = "DL" });
            Insert.IntoTable("State").Row(new { Name = "Jammu and Kashmir", CountryId = 1, StateCode = "JK" });
            Insert.IntoTable("State").Row(new { Name = "Ladakh", CountryId = 1, StateCode = "LA" });
            Insert.IntoTable("State").Row(new { Name = "Lakshadweep", CountryId = 1, StateCode = "LD" });
            Insert.IntoTable("State").Row(new { Name = "Puducherry", CountryId = 1, StateCode = "PY" });

        }
    }
}
