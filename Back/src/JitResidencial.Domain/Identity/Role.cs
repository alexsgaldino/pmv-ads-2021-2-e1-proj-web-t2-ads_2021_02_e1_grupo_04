using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace JitResidencial.Domain.Identity
{
    public class Role: IdentityRole<int>
    {
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}