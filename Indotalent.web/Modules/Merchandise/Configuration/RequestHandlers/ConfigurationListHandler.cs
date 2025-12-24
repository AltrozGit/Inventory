using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<Indotalent.Merchandise.ConfigurationRow>;
using MyRow = Indotalent.Merchandise.ConfigurationRow;

namespace Indotalent.Merchandise
{
    public interface IConfigurationListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ConfigurationListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IConfigurationListHandler
    {
        public ConfigurationListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}