using Serenity.ComponentModel;
using Serenity.Services;
using System;
using System.ComponentModel;

namespace Indotalent.Membership
{
    [FormScript("Membership.ForgotPassword")]
    public class ForgotPasswordRequest : ServiceRequest
    {
        [Required(true), DisplayName("E-mail Address")]
        public String Email { get; set; }
    }
}