using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.Merchandise.ConfigurationRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.Merchandise.ConfigurationRow;

namespace Indotalent.Merchandise
{
    public interface IConfigurationSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ConfigurationSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IConfigurationSaveHandler
    {
        public ConfigurationSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}