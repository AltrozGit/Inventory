using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Material.IssueDetailRow>;
using MyRow = Indotalent.Material.IssueDetailRow;

namespace Indotalent.Material
{
    public interface IIssueDetailListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class IssueDetailListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IIssueDetailListHandler
    {
        public IssueDetailListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}