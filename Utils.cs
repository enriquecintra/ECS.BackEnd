using BackEnd.Models;
using System.Security.Claims;
using System.Text.Json;

namespace BackEnd
{
    public static class Utils
    {
        public static User GetUserContext(ClaimsPrincipal claimIdentity)
        {
            return JsonSerializer.Deserialize<User>(claimIdentity.FindFirst(ClaimTypes.UserData).Value);
        }
    }
    public static class StringExtension
    {
        public static string ToCamelCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return char.ToLowerInvariant(str[0]) + str.Substring(1);
            }
            return str;
        }
    }
}
