using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebAppli.Models;

namespace WebAppli.Security
{
    public class SecurityManager
    {
        public async void SignIn(HttpContext httpContext, Account account)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme,ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, account.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Name, account.UserName));
            identity.AddClaims(getUserClaims(account));
            var principal = new ClaimsPrincipal(identity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });
        }

        public async void SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        private IEnumerable<Claim> getUserClaims(Account account)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, account.UserName));
            foreach (var roleAccount in account.RoleAccounts)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleAccount.Role.Name));
            }
            return claims;
        }
    }
}
