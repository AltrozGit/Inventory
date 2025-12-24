using Serenity.ComponentModel;
using Serenity.Services;
using System.ComponentModel;

namespace Indotalent.Membership
{
    [FormScript("Membership.ChangePassword")]
    public class ChangePasswordRequest : ServiceRequest
    {
        [PasswordEditor, Required(true), DisplayName("New Password"), HalfWidth]
        public string NewPassword { get; set; }
        [PasswordEditor, Required(true), DisplayName("Current Password"), HalfWidth]
        public string OldPassword { get; set; }
        [PasswordEditor, Required(true), DisplayName("Confirm Password"), HalfWidth]
        public string ConfirmPassword { get; set; }
    }
}