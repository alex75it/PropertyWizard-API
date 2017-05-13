using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PropertyWizard.WebApi.Models;

namespace PropertyWizard.WebApi
{
    internal class UserStore : IUserStore<ApplicationUser>
    {
        public UserStore()
        {
        }

        public Task CreateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // nothing to do
        }
    }
}