using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.WhatsApp.WhatsAppTemplateRow>;
using MyRow = Indotalent.WhatsApp.WhatsAppTemplateRow;

namespace Indotalent.WhatsApp
{
    public interface IWhatsAppTemplateRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class WhatsAppTemplateRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IWhatsAppTemplateRetrieveHandler
    {
        public WhatsAppTemplateRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}