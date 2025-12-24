using Indotalent.Administration;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Projects.ProjectMaterialRequestRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Projects.ProjectMaterialRequestRow;

namespace Indotalent.Projects
{
    public interface IProjectMaterialRequestSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectMaterialRequestSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IProjectMaterialRequestSaveHandler
    {
        public ProjectMaterialRequestSaveHandler(IRequestContext context)
             : base(context)
        {
        }
        protected override void BeforeSave()
        {
            base.BeforeSave();


            if (Row.ItemList != null)
            {

                Row.TotalQtyRequest = 0;
                foreach (var item in Row.ItemList)
                {
                    Row.TotalQtyRequest += item.QtyRequest;
                }
            }

            if (this.IsCreate)
            {
                if (Row.Number.ToLower().Equals("auto"))
                {
                    var tenant = UnitOfWork.Connection.ById<TenantRow>(Row.TenantId);
                    var request = new GetNextNumberRequest()
                    {
                        Prefix = tenant.MaterialRequestNumberUseDate.Value ? "PMR"+ "/" + DateTime.Now.ToString("yyyyMMdd") : tenant.MaterialRequestNumberPrefix,
                        Length = tenant.MaterialRequestNumberLength.Value
                    };
                    var respone = MultiTenantHelper.GetNextNumber(UnitOfWork.Connection, request, MyRow.Fields.Number, tenant.TenantId);
                    Row.Number = respone.Serial;
                }

            }
        }
    }
}



