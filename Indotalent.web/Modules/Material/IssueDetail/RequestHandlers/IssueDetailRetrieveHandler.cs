using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Material.IssueDetailRow>;
using MyRow = Indotalent.Material.IssueDetailRow;

namespace Indotalent.Material
{
    public interface IIssueDetailRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class IssueDetailRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IIssueDetailRetrieveHandler
    {
        public IssueDetailRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}