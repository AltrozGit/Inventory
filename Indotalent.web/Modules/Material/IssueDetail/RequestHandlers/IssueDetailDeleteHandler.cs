using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Material.IssueDetailRow;

namespace Indotalent.Material
{
    public interface IIssueDetailDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class IssueDetailDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IIssueDetailDeleteHandler
    {
        public IssueDetailDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}