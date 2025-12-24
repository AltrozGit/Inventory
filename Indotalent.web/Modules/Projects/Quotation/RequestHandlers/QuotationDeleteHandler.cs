using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Projects.QuotationRow;

namespace Indotalent.Projects
{
    public interface IQuotationDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class QuotationDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IQuotationDeleteHandler
    {
        public QuotationDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}