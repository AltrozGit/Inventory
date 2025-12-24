using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Material.MaterialReturnDetailRow;

namespace Indotalent.Material
{
    public interface IMaterialReturnDetailDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class MaterialReturnDetailDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialReturnDetailDeleteHandler
    {
        public MaterialReturnDetailDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}