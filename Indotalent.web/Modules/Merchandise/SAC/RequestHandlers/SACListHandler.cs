using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Merchandise.SACRow>;
using MyRow = Indotalent.Merchandise.SACRow;

namespace Indotalent.Merchandise
{
    public interface ISACListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class SACListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ISACListHandler
    {
        public SACListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}