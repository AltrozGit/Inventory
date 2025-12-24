using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Material.IssueRow>;
using MyRow = Indotalent.Material.IssueRow;

namespace Indotalent.Material
{
    public interface IIssueRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class IssueRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IIssueRetrieveHandler
    {
        public IssueRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}