using System.Security.Claims;

namespace JitResidencial.API.Extensions
{
    public static class ClaimsPrincipalExtensions 
    {
        public static string GetUserName(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value; 
        }
        public static int GerUserId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
     }

}