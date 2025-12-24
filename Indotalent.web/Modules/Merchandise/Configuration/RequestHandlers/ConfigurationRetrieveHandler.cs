using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Indotalent.Merchandise.ConfigurationRow>;
using MyRow = Indotalent.Merchandise.ConfigurationRow;

namespace Indotalent.Merchandise
{
    public interface IConfigurationRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ConfigurationRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IConfigurationRetrieveHandler
    {
        public ConfigurationRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}