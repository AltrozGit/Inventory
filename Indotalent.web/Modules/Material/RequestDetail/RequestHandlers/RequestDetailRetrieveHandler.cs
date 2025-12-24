using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Material.RequestDetailRow>;
using MyRow = Indotalent.Material.RequestDetailRow;

namespace Indotalent.Material
{
    public interface IRequestDetailRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class RequestDetailRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IRequestDetailRetrieveHandler
    {
        public RequestDetailRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}