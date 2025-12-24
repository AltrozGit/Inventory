using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Material.MaterialRequestStatusRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Material.MaterialRequestStatusRow;

namespace Indotalent.Material
{
    public interface IMaterialRequestStatusSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class MaterialRequestStatusSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialRequestStatusSaveHandler
    {
        public MaterialRequestStatusSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}