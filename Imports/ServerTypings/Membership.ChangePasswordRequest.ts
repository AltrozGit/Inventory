namespace Indotalent.Membership {
    export interface ChangePasswordRequest extends Serenity.ServiceRequest {
        NewPassword?: string;
        OldPassword?: string;
        ConfirmPassword?: string;
    }
}
