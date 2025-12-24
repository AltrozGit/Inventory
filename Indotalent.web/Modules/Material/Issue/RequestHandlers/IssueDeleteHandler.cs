using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Material.IssueRow;

namespace Indotalent.Material
{
    public interface IIssueDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class IssueDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IIssueDeleteHandler
    {
        public IssueDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}