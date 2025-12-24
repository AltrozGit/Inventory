using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Material.RequestDetailRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Material.RequestDetailRow;

namespace Indotalent.Material
{
    public interface IRequestDetailSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

    public class RequestDetailSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IRequestDetailSaveHandler
    {
        public RequestDetailSaveHandler(IRequestContext context)
             : base(context)
        {
        }

        protected override void BeforeSave()
        {
            base.BeforeSave();


            if (this.IsCreate)
            {
                if (Row.QtyRequest <= 0 && Row.TotalQtyRequest <=0)
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
