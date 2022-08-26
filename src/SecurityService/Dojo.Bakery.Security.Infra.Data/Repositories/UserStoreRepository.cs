using Dojo.Bakery.Security.Domain;
using Microsoft.AspNetCore.Identity;

namespace Dojo.Bakery.Security.Infra.Data.Repositories
{
    public class UserStoreRepository : IUserStore<ApplicationUser>
    {
        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return new IdentityResult();
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return new IdentityResult();
        }

        public void Dispose()
        {

        }

        public async Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return null;
        }

        public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return null;
        }

        public async Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return null;
        }

        public async Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return null;
        }

        public async Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return null;
        }

        public async Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {

        }

        public async Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {

        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return new IdentityResult();
        }
    }
}
