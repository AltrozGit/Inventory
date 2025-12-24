using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Indotalent.Merchandise.ConfigurationRow;

namespace Indotalent.Merchandise
{
    public interface IConfigurationDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ConfigurationDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IConfigurationDeleteHandler
    {
        public ConfigurationDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}