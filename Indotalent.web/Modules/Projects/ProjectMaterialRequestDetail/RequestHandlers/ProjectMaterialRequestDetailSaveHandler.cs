using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Projects.ProjectMaterialRequestDetailRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Projects.ProjectMaterialRequestDetailRow;

namespace Indotalent.Projects
{
    public interface IProjectMaterialRequestDetailSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ProjectMaterialRequestDetailSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IProjectMaterialRequestDetailSaveHandler
    {
        public ProjectMaterialRequestDetailSaveHandler(IRequestContext context)
             : base(context)
        {
        }
        protected override void BeforeSave()
        {
            base.BeforeSave();


            if (this.IsCreate)
            {
                if (Row.QtyRequest <= 0 && Row.TotalQtyRequest <= 0)
                {
                    throw new Exception("Quantity Request and Total Quantity Request must be greater than 0.");
                }
            }
            else
            {
                if (Row.QtyRequest <= 0 && Row.TotalQtyRequest <= 0)
                {
                    throw new Exception("Quantity Request and Total Quantity Request must be greater than 0.");
                }
            }


        }
    }
}
