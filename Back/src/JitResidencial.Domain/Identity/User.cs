using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace JitResidencial.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageURL { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}