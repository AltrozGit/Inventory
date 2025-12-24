using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.WhatsApp.WhatsAppTemplateRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.WhatsApp.WhatsAppTemplateRow;

namespace Indotalent.WhatsApp
{
    public interface IWhatsAppTemplateSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class WhatsAppTemplateSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IWhatsAppTemplateSaveHandler
    {
        public WhatsAppTemplateSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}