namespace Indotalent.Web.Common {
    export enum EmailSentStatus {
        Pending = 0,
        Successful = 1,
        Cancelled = 2
    }
    Serenity.Decorators.registerEnumType(EmailSentStatus, 'Indotalent.Web.Common.EmailSentStatus', 'Custom.EmailSentStatus');
}
