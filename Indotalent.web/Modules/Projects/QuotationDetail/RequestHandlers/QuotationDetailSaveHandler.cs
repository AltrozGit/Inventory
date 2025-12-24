using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Projects.QuotationDetailRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Projects.QuotationDetailRow;

namespace Indotalent.Projects
{
    public interface IQuotationDetailSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class QuotationDetailSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IQuotationDetailSaveHandler
    {
        public QuotationDetailSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}