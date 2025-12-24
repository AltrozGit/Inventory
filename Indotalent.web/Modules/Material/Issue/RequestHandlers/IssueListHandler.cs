using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Material.IssueRow>;
using MyRow = Indotalent.Material.IssueRow;

namespace Indotalent.Material
{
    public interface IIssueListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class IssueListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IIssueListHandler
    {
        public IssueListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}