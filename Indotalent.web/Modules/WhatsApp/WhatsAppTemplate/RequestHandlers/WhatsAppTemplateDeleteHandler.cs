using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.WhatsApp.WhatsAppTemplateRow;

namespace Indotalent.WhatsApp
{
    public interface IWhatsAppTemplateDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class WhatsAppTemplateDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IWhatsAppTemplateDeleteHandler
    {
        public WhatsAppTemplateDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}