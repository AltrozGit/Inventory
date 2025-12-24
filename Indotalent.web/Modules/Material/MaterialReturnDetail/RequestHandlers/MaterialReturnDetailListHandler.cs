using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Material.MaterialReturnDetailRow>;
using MyRow = Indotalent.Material.MaterialReturnDetailRow;

namespace Indotalent.Material
{
    public interface IMaterialReturnDetailListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class MaterialReturnDetailListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialReturnDetailListHandler
    {
        public MaterialReturnDetailListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}