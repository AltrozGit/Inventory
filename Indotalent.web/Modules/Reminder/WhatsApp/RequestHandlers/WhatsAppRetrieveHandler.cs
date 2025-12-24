using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Reminder.WhatsAppRow>;
using MyRow = Indotalent.Reminder.WhatsAppRow;

namespace Indotalent.Reminder
{
    public interface IWhatsAppRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class WhatsAppRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IWhatsAppRetrieveHandler
    {
        public WhatsAppRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}