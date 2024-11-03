using E_Tickets.ViewModel;
using E_Tickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.IdentityModel.Tokens;
using E_Tickets.Utility;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Text.Encodings.Web;
using System.Text;
using IEmailSender = E_Tickets.Utility.IEmailSender;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace E_Tickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IEmailSender emailSender;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager , RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.emailSender = emailSender;
        }

        public async Task<IActionResult> Register()
        {
            if (roleManager.Roles.IsNullOrEmpty())
            {
                await roleManager.CreateAsync(new(SD.AdminRole));
                await roleManager.CreateAsync(new(SD.CompanyRole));
                await roleManager.CreateAsync(new(SD.UserRole));

            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Register(ApplicationUserVM UserVM)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser user = new ApplicationUser
                {
                    UserName = UserVM.UserName,
                    Email = UserVM.Email,
                };
                var result = await userManager.CreateAsync(user, UserVM.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user , SD.UserRole);
                   await signInManager.SignInAsync(user, false);

                    await emailSender.SendEmailAsync(user.Email, "confirmation", "bla bla");

                    return RedirectToAction("LogIn");
                }

                ModelState.AddModelError("Password", "password must be more than 8 characters that contain alphanumeric and special characters");
            }

            return View(UserVM);
        }


  
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInVM UserVM)
        {
            if (ModelState.IsValid)
            {
                var User = await userManager.FindByNameAsync(UserVM.UserName);
                if (User != null)
                {
                 var result = await userManager.CheckPasswordAsync(User, UserVM.Password);

                    if (result)
                    {
                        await signInManager.SignInAsync(User, UserVM.RememberMe);
                        return RedirectToAction("Welcome", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("Password", "The User Name or Password Is Wrong");
                    }
                }
               
            }

            return View(UserVM);
        }
        [HttpGet]
        public IActionResult LogInWithGoogle(string returnUrl = "/")
        {
            var redirectUrl = Url.Action("GoogleResponse", "Account", new { ReturnUrl = returnUrl });
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public async Task<IActionResult> GoogleResponse(string returnUrl = "/")
        {
            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                Console.WriteLine("No external login info available.");
                ModelState.AddModelError(string.Empty, "Error loading external login information.");
                return RedirectToAction("Login");
            }

            var signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            if (signInResult.Succeeded)
            {
                Console.WriteLine("User signed in successfully.");
                return LocalRedirect(returnUrl);
            }

            // Check if user needs to be created
            var userEmail = info.Principal.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(userEmail))
            {
                Console.WriteLine("No email claim found.");
                ModelState.AddModelError(string.Empty, "Email claim not found.");
                return RedirectToAction("Login");
            }

            var user = await userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                user = new ApplicationUser { UserName = userEmail, Email = userEmail, EmailConfirmed = true };
                var createResult = await userManager.CreateAsync(user);
                if (createResult.Succeeded)
                {
                    await userManager.AddLoginAsync(user, info);
                    await signInManager.SignInAsync(user, isPersistent: false);
                    Console.WriteLine("User created and signed in.");
                    return LocalRedirect(returnUrl);
                }
            }

            Console.WriteLine("An error occurred during the external login process.");
            ModelState.AddModelError(string.Empty, "An error occurred during the external login process.");
            return RedirectToAction("Login");
        }

        //public async Task<IActionResult> ExternalLoginCallback(string returnUrl = "/", string remoteError = null)
        //{
        //    if (!string.IsNullOrEmpty(remoteError))
        //    {
        //        ModelState.AddModelError(string.Empty, $"Error from external login provider: {remoteError}");
        //        return View("Login"); // Adjust to your actual login view
        //    }

        //    // Get login information from the external provider
        //    var info = await signInManager.GetExternalLoginInfoAsync();
        //    if (info == null)
        //    {
        //        ModelState.AddModelError(string.Empty, "Error loading external login information.");
        //        return View("Login");
        //    }

        //    // Sign in with the external login provider if the user already has an account
        //    var signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

        //    if (signInResult.Succeeded)
        //    {
        //        return LocalRedirect(returnUrl);
        //    }
        //    else
        //    {
        //        // If the user does not have an account, create one based on their external login info
        //        var userEmail = info.Principal.FindFirstValue(ClaimTypes.Email);
        //        if (!string.IsNullOrEmpty(userEmail))
        //        {
        //            var user = await userManager.FindByEmailAsync(userEmail);

        //            if (user == null)
        //            {
        //                user = new ApplicationUser
        //                {
        //                    UserName = userEmail,
        //                    Email = userEmail,
        //                    EmailConfirmed = true
        //                };

        //                var createResult = await userManager.CreateAsync(user);
        //                if (createResult.Succeeded)
        //                {
        //                    await userManager.AddLoginAsync(user, info);
        //                    await signInManager.SignInAsync(user, isPersistent: false);

        //                    return LocalRedirect(returnUrl);
        //                }
        //            }
        //            else
        //            {
        //                await userManager.AddLoginAsync(user, info);
        //                await signInManager.SignInAsync(user, isPersistent: false);

        //                return LocalRedirect(returnUrl);
        //            }
        //        }
        //    }

        //    ModelState.AddModelError(string.Empty, "Something went wrong during the external login process.");
        //    return View("Login");
        //}
        //[HttpGet]
        //public IActionResult GoogleResponse(string returnUrl = "/")
        //{

        //    if (User.Identity?.IsAuthenticated == true)
        //    {
        //        return LocalRedirect(returnUrl);
        //    }


        //    return RedirectToAction("Login", "Account");
        //}





        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
