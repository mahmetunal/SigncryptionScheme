using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebSigncryptionImplementation.Models;

namespace WebSigncryptionImplementation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            user.GenerateAndSetIdNumber(Participants.ParticipantsList.Count + 1);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id)
            };

            var identity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme
                );
            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties();

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

            user.isSignedIn = true;
            user.SessionKey = HttpContext.Request.Cookies["SigncryptionCookie"];
            Participants.ParticipantsList.Add(user.Id, user);

            ViewData["User"] = user;
            return RedirectToAction("Index", "Game");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

    }
}
