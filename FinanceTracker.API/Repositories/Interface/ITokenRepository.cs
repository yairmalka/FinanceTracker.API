using FinanceTracker.API.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace FinanceTracker.API.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(ApplicationUser user, List<string> roles);
    }
}
