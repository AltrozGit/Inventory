using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace Indotalent.Membership
{
    [FormScript("Membership.SignUp")]
    public class SignUpForm
    {
        [Required(true), Placeholder("Company name"), DisplayName("Company Name")]
        public String CompanyName { get; set; }
        [Required(true), Placeholder("Full name")]
        public String DisplayName { get; set; }
        [Required(true), Placeholder("Email")]
        public String Email { get; set; }
        [Required(true), Placeholder("Confirm email")]
        public String ConfirmEmail { get; set; }
        [PasswordEditor, Required(true), Placeholder("Password")]
        public String Password { get; set; }
        [PasswordEditor, Required(true), Placeholder("Confirm password")]
        public String ConfirmPassword { get; set; }
    }
}
