namespace Indotalent.Membership {
    export interface SignUpForm {
        CompanyName: Serenity.StringEditor;
        DisplayName: Serenity.StringEditor;
        Email: Serenity.StringEditor;
        ConfirmEmail: Serenity.StringEditor;
        Password: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }

    export class SignUpForm extends Serenity.PrefixedContext {
        static formKey = 'Membership.SignUp';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!SignUpForm.init)  {
                SignUpForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.PasswordEditor;

                Q.initFormType(SignUpForm, [
                    'CompanyName', w0,
                    'DisplayName', w0,
                    'Email', w0,
                    'ConfirmEmail', w0,
                    'Password', w1,
                    'ConfirmPassword', w1
                ]);
            }
        }
    }
}
