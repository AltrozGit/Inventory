using Serenity.ComponentModel;
using Serenity.Services;

namespace Indotalent.Membership
{
    [FormScript("Membership.Login")]
    [BasedOnRow(typeof(Administration.Entities.UserRow), CheckNames = true)]
    public class LoginRequest : ServiceRequest
    {
        [Placeholder("username..")]
        public string Username { get; set; }
        [PasswordEditor, Placeholder("password.."), Required(true)]
        public string Password { get; set; }
    }
}