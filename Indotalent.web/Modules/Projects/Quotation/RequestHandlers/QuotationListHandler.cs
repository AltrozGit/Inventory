using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Projects.QuotationRow>;
using MyRow = Indotalent.Projects.QuotationRow;

namespace Indotalent.Projects
{
    public interface IQuotationListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class QuotationListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IQuotationListHandler
    {
        public QuotationListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}