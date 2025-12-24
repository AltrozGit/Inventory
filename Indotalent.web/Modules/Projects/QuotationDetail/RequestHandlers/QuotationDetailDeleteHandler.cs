using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Projects.QuotationDetailRow;

namespace Indotalent.Projects
{
    public interface IQuotationDetailDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class QuotationDetailDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IQuotationDetailDeleteHandler
    {
        public QuotationDetailDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}