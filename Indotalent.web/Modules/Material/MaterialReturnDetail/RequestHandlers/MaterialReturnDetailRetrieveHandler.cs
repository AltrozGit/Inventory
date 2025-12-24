using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Material.MaterialReturnDetailRow>;
using MyRow = Indotalent.Material.MaterialReturnDetailRow;

namespace Indotalent.Material
{
    public interface IMaterialReturnDetailRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class MaterialReturnDetailRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialReturnDetailRetrieveHandler
    {
        public MaterialReturnDetailRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}