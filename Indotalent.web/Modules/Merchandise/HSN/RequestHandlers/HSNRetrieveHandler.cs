using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Merchandise.HSNRow>;
using MyRow = Indotalent.Merchandise.HSNRow;

namespace Indotalent.Merchandise
{
    public interface IHSNRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class HSNRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IHSNRetrieveHandler
    {
        public HSNRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}