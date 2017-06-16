using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BookishNet.DataLayer.Models;
using BookishNet.Mvc.Utilities;
using BookishNet.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookishNet.Mvc.Controllers.Api
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IRoleService _roleService;


        private readonly IUserService _userService;

        public AccountController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginCredentialsDTO loginCredentials, string returnUrl = null)
        {
            var claims = new List<Claim>();
            var user = _userService.GetUserByUsername(loginCredentials.Username);
            if (!Utility.CheckPassword(loginCredentials.Password, user.Password))
                return UserNotFound();
            claims.Add(new Claim(ClaimTypes.Name, loginCredentials.Username, ClaimValueTypes.String));

            var role = _roleService.GetRoleOfUser(user);

            //Added Claim.Role 
            claims.Add(new Claim(ClaimTypes.Role, role, ClaimValueTypes.String));
            var userIdentity = new ClaimsIdentity("BookishNetSecureLogin");
            userIdentity.AddClaims(claims);
            var userPrincipal = new ClaimsPrincipal(userIdentity);


            await HttpContext.Authentication.SignInAsync("BookishNetCookie", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(5),
                    IsPersistent = true,
                    AllowRefresh = true
                });

            return RedirectToLocal(returnUrl, role);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] User user)
        {
            user.Password = Utility.Encryptpassword(user.Password);
            _userService.Add(user);
            return Ok("register succesfull");
        }

        [Authorize]
        [HttpGet]
        [Route("logout")]
        public IActionResult LogOff()
        {
            HttpContext.Authentication.SignOutAsync("BookishNetCookie");
            return Ok("logged off");
        }


        [HttpGet]
        public IActionResult Unauthorized()
        {
            return NotFound();
        }

        private IActionResult RedirectToLocal(string returnUrl, string role)
        {
            string[] response = {"authenticated", role};
            var jsonResponse = JsonConvert.SerializeObject(response);

            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return Ok(jsonResponse);
        }

        private IActionResult UserNotFound()
        {
            string[] response = {"failed"};
            var jsonResponse = JsonConvert.SerializeObject(response);
            return Ok(jsonResponse);
        }
    }
}