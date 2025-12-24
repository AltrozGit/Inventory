using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Material.RequestDetailRow;

namespace Indotalent.Material
{
    public interface IRequestDetailDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class RequestDetailDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IRequestDetailDeleteHandler
    {
        public RequestDetailDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}