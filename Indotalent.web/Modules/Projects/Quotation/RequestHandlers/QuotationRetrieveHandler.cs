using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Projects.QuotationRow>;
using MyRow = Indotalent.Projects.QuotationRow;

namespace Indotalent.Projects
{
    public interface IQuotationRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class QuotationRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IQuotationRetrieveHandler
    {
        public QuotationRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}