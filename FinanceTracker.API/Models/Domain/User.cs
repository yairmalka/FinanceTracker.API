using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.Domain
{
        public class User
        {
            [Key]
            public Guid UserId { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; }
            public Guid RoleId { get; set; }
            [ForeignKey("RoleId")]
            public Role Role { get; set; }
            public string Email { get; set; }
            public string FullName { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
}
