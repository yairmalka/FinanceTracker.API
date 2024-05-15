using Microsoft.AspNetCore.Identity;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
