using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Merchandise.SACRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Merchandise.SACRow;

namespace Indotalent.Merchandise
{
    public interface ISACSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class SACSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISACSaveHandler
    {
        public SACSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}