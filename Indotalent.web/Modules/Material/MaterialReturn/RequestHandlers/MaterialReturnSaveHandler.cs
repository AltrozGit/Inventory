using Indotalent.Administration;
using Serenity;

using Serenity.Data;

using Serenity.Services;

using System;

using System.Data;

using MyRequest = Serenity.Services.SaveRequest<Indotalent.Material.MaterialReturnRow>;

using MyResponse = Serenity.Services.SaveResponse;

using MyRow = Indotalent.Material.MaterialReturnRow;

namespace Indotalent.Material

{

    public interface IMaterialReturnSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

    public class MaterialReturnSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialReturnSaveHandler

    {

        public MaterialReturnSaveHandler(IRequestContext context)

             : base(context)

        {

        }

        protected override void BeforeSave()
        {
            base.BeforeSave();

           
            if (this.IsCreate)
            {
                Row.TotalQtyReturn = 0;
                foreach (var item in Row.ItemList)
                {
                    Row.TotalQtyReturn += item.QtyReturn;
                }

                if (Row.Number.ToLower().Equals("auto"))
                {
                    var tenant = UnitOfWork.Connection.ById<TenantRow>(Row.TenantId);
                    var request = new GetNextNumberRequest()
                    {
                        Prefix = tenant.MaterialReturnNumberUseDate.Value ? tenant.MaterialReturnNumberPrefix + "/" + DateTime.Now.ToString("yyyyMMdd") : tenant.MaterialReturnNumberPrefix,
                        Length = tenant.MaterialReturnNumberLength.Value
                    };
                    var respone = MultiTenantHelper.GetNextNumber(UnitOfWork.Connection, request, MyRow.Fields.Number, tenant.TenantId);
                    Row.Number = respone.Serial;
                }

            }
        }

    }

}
