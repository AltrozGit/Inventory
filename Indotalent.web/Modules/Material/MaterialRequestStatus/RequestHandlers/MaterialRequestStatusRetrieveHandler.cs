using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Material.MaterialRequestStatusRow>;
using MyRow = Indotalent.Material.MaterialRequestStatusRow;

namespace Indotalent.Material
{
    public interface IMaterialRequestStatusRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class MaterialRequestStatusRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialRequestStatusRetrieveHandler
    {
        public MaterialRequestStatusRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}