using Microsoft.AspNetCore.Identity;

namespace FinanceTracker.API.Models.Domain
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
