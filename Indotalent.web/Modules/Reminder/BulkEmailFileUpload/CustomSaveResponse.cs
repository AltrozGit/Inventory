using Serenity.Services;
using System.Collections.Generic;

namespace Indotalent.Web.Modules.Reminder.BulkEmailFileUpload
{
    public class CustomSaveResponse : SaveResponse
    {
        public List<string> SuccessMessages { get; set; }
        public List<string> ErrorMessages { get; set; }
        public string CustomErrorMessage { get; internal set; }
        public string CustomWarningMessage { get; internal set; }

        public CustomSaveResponse(SaveResponse saveResponse)
        {
            EntityId = saveResponse.EntityId;
            Error = saveResponse.Error;
            SuccessMessages = new List<string>();
            ErrorMessages = new List<string>();
        }

        public CustomSaveResponse(SaveResponse saveResponse, List<string> successMessages, List<string> errorMessages)
            : this(saveResponse)
        {
            SuccessMessages = successMessages;
            ErrorMessages = errorMessages;
        }

        public CustomSaveResponse()
        {
        }
    }
}
