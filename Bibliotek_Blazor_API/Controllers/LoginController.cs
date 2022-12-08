using Bibliotek_Blazor_API.Data;
using Bibliotek_Blazor_API.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Bibliotek_Blazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILocalStorageService _localstorage;
        private readonly BibliotekContext _db;

        public LoginController(BibliotekContext db)
        {
            _db = db;
        }

        private static readonly AuthenticationProperties COOKIE_EXPIRES = new AuthenticationProperties()
        {
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            IsPersistent = true,
        };

        [Route("Logout")]
        [HttpGet]
        public async Task<bool> Logout()
        {
            try
            {
                // Clear the existing external cookie
                await HttpContext
                    .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                return true;    
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        public async Task<UserToken?> Index(string username, string password)
        {
            User? user = null;


            // Clear the existing external cookie
            await Logout();

            try
            {
                user = await _db.Users.FirstOrDefaultAsync(usr => usr.Username == username);
                if (user == null || user.Password != password)
                {
                    return null;
                }

                UserToken token = new UserToken
                {
                    LoginGuid = Guid.NewGuid(),
                    UserId = user.Id
                };
                _db.UserToken.Add(token);
                await _db.SaveChangesAsync();

                return token;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}
