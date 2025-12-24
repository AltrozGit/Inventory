using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Material.RequestRow>;
using MyRow = Indotalent.Material.RequestRow;

namespace Indotalent.Material
{
    public interface IRequestRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class RequestRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IRequestRetrieveHandler
    {
        public RequestRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}