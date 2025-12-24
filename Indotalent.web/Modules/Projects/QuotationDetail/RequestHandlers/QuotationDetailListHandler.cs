using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Projects.QuotationDetailRow>;
using MyRow = Indotalent.Projects.QuotationDetailRow;

namespace Indotalent.Projects
{
    public interface IQuotationDetailListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class QuotationDetailListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IQuotationDetailListHandler
    {
        public QuotationDetailListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}