using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Material.MaterialRequestTrackingRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Material.MaterialRequestTrackingRow;

namespace Indotalent.Material
{
    public interface IMaterialRequestTrackingSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class MaterialRequestTrackingSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialRequestTrackingSaveHandler
    {
        public MaterialRequestTrackingSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}