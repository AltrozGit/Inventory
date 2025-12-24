using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Material.MaterialReturnRow>;
using MyRow = Indotalent.Material.MaterialReturnRow;

namespace Indotalent.Material
{
    public interface IMaterialReturnListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

    public class MaterialReturnListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialReturnListHandler
    {
        public MaterialReturnListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}