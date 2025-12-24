using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Material.MaterialRequestTrackingRow;

namespace Indotalent.Material
{
    public interface IMaterialRequestTrackingDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class MaterialRequestTrackingDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialRequestTrackingDeleteHandler
    {
        public MaterialRequestTrackingDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}