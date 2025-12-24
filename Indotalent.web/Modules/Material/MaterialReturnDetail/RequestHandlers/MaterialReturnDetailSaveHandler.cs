using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Material.MaterialReturnDetailRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Material.MaterialReturnDetailRow;

namespace Indotalent.Material
{
    public interface IMaterialReturnDetailSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class MaterialReturnDetailSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialReturnDetailSaveHandler
    {
        public MaterialReturnDetailSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}