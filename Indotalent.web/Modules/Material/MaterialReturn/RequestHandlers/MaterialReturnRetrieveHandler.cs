using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Material.MaterialReturnRow>;
using MyRow = Indotalent.Material.MaterialReturnRow;

namespace Indotalent.Material
{
    public interface IMaterialReturnRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

    public class MaterialReturnRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialReturnRetrieveHandler
    {
        public MaterialReturnRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}