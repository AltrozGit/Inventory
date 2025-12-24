using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Reminder.WhatsAppRow;

namespace Indotalent.Reminder
{
    public interface IWhatsAppDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class WhatsAppDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IWhatsAppDeleteHandler
    {
        public WhatsAppDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}