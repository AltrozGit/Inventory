using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Material.MaterialRequestStatusRow>;
using MyRow = Indotalent.Material.MaterialRequestStatusRow;

namespace Indotalent.Material
{
    public interface IMaterialRequestStatusListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class MaterialRequestStatusListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialRequestStatusListHandler
    {
        public MaterialRequestStatusListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}