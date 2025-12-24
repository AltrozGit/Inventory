namespace Indotalent.Administration {
    export interface UserProjectsUpdateRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Projects?: number[];
    }
}
