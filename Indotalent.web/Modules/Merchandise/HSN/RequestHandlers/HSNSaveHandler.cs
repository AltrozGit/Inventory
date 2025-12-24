using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Merchandise.HSNRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Merchandise.HSNRow;

namespace Indotalent.Merchandise
{
    public interface IHSNSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class HSNSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IHSNSaveHandler
    {
        public HSNSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}