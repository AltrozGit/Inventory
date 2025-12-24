using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Reminder.WhatsAppRow>;
using MyRow = Indotalent.Reminder.WhatsAppRow;

namespace Indotalent.Reminder
{
    public interface IWhatsAppListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class WhatsAppListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IWhatsAppListHandler
    {
        public WhatsAppListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}