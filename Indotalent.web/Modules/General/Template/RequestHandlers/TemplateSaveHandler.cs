using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<Indotalent.General.TemplateRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Indotalent.General.TemplateRow;

namespace Indotalent.General
{
    public interface ITemplateSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class TemplateSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ITemplateSaveHandler
    {
        public TemplateSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}