using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Material.MaterialRequestTrackingRow>;
using MyRow = Indotalent.Material.MaterialRequestTrackingRow;

namespace Indotalent.Material
{
    public interface IMaterialRequestTrackingRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class MaterialRequestTrackingRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialRequestTrackingRetrieveHandler
    {
        public MaterialRequestTrackingRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}