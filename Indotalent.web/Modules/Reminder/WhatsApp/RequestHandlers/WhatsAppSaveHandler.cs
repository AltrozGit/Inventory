using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Reminder.WhatsAppRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Reminder.WhatsAppRow;

namespace Indotalent.Reminder
{
    public interface IWhatsAppSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class WhatsAppSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IWhatsAppSaveHandler
    {
        public WhatsAppSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}