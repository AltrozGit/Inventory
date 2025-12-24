using Serenity;

using Serenity.Data;

using Serenity.Services;

using System;

using System.Data;

using MyRequest = Serenity.Services.DeleteRequest;

using MyResponse = Serenity.Services.DeleteResponse;

using MyRow = Indotalent.Material.MaterialReturnRow;

namespace Indotalent.Material

{

    public interface IMaterialReturnDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

    public class MaterialReturnDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IMaterialReturnDeleteHandler

    {

        public MaterialReturnDeleteHandler(IRequestContext context)

             : base(context)

        {

        }

    }

}
