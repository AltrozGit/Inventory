using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Material.MaterialRequestTrackingRow>;
using MyRow = Indotalent.Material.MaterialRequestTrackingRow;

namespace Indotalent.Material
{
    public interface IMaterialRequestTrackingListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class MaterialRequestTrackingListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialRequestTrackingListHandler
    {
        public MaterialRequestTrackingListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}