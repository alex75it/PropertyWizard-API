using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using Web_API;

namespace PropertyWizard.WebApi.Models
{
    public class ApplicationUser : IUser<string>
    {
        public string Email { get; internal set; }
        public string Id { get; private set; }
        public IEnumerable<IdentityUserLogin> Logins { get; internal set; }
        public object PasswordHash { get; internal set; }
        public string UserName { get; set; }

        internal Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager userManager, string authenticationType)
        {
            throw new NotImplementedException();
        }
    }
}