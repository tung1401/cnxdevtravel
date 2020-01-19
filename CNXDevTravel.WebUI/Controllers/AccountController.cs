using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CNXDevTravel.WebUI.Controllers
{
    [Controller]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login(
            [FromForm] string username,
            [FromForm] string name,
            [FromForm] string role,
            [FromForm] string department,
            [FromForm] string profileimageurl,
            [FromForm] string token)
        {
            try
            {
                // Clear the existing external cookie
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch { }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, name),
                new Claim("ProfileImage", profileimageurl),
                new Claim("Token", token)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = this.Request.Host.Value,
                ExpiresUtc = DateTime.UtcNow.AddDays(1)
            };
            try
            {
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch { }
            return Redirect("/");
        }
    }
}
