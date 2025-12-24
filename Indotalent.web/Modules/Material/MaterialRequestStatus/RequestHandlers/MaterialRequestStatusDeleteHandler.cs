using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Material.MaterialRequestStatusRow;

namespace Indotalent.Material
{
    public interface IMaterialRequestStatusDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class MaterialRequestStatusDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialRequestStatusDeleteHandler
    {
        public MaterialRequestStatusDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}