using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Projects.QuotationDetailRow>;
using MyRow = Indotalent.Projects.QuotationDetailRow;

namespace Indotalent.Projects
{
    public interface IQuotationDetailRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class QuotationDetailRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IQuotationDetailRetrieveHandler
    {
        public QuotationDetailRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}