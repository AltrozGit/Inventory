using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Merchandise.SACRow>;
using MyRow = Indotalent.Merchandise.SACRow;

namespace Indotalent.Merchandise
{
    public interface ISACRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class SACRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ISACRetrieveHandler
    {
        public SACRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}