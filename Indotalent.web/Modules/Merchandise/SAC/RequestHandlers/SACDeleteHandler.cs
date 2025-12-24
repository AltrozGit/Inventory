using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Merchandise.SACRow;

namespace Indotalent.Merchandise
{
    public interface ISACDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class SACDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ISACDeleteHandler
    {
        public SACDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}