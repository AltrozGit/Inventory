using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.WhatsApp.WhatsAppTemplateRow>;
using MyRow = Indotalent.WhatsApp.WhatsAppTemplateRow;

namespace Indotalent.WhatsApp
{
    public interface IWhatsAppTemplateListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class WhatsAppTemplateListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IWhatsAppTemplateListHandler
    {
        public WhatsAppTemplateListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}