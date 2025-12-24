namespace Indotalent.Membership {
    export interface ChangePasswordForm {
        NewPassword: Serenity.PasswordEditor;
        OldPassword: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }

    export class ChangePasswordForm extends Serenity.PrefixedContext {
        static formKey = 'Membership.ChangePassword';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ChangePasswordForm.init)  {
                ChangePasswordForm.init = true;

                var s = Serenity;
                var w0 = s.PasswordEditor;

                Q.initFormType(ChangePasswordForm, [
                    'NewPassword', w0,
                    'OldPassword', w0,
                    'ConfirmPassword', w0
                ]);
            }
        }
    }
}
