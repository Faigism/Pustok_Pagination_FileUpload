using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Pustok_DbStructure.Entities;
using Pustok_DbStructure.ViewModels;

namespace Pustok_DbStructure.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly Email.IMailService _mailService;

        public AccountController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,SignInManager<AppUser> signInManager, Email.IMailService mailService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mailService = mailService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(MemberRegister_VM registerVM)
        {
            if(!ModelState.IsValid) return View();
            AppUser user = new AppUser
            {
                FullName = registerVM.FullName,
                Email = registerVM.Email,
                UserName = registerVM.UserName,
                PhoneNumber = registerVM.Phone
            };
            var result = await _userManager.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(user, "Member");
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(MemberLogin_VM loginVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser member = await _userManager.FindByNameAsync(loginVM.UserName);
            if (member == null)
            {
                ModelState.AddModelError("", "UserName incorrect");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(member, loginVM.Password, false, false);
            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Password incorrect");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles ="Member")]
        public async Task<IActionResult> Profile()
        {
            AppUser member = await _userManager.FindByNameAsync(User.Identity.Name);
            Profile_VM vm = new Profile_VM
            {
                Member = new MemberUpdate_VM
                {
                    FullName = member.FullName,
                    Email = member.Email,
                    UserName = member.UserName,
                    Phone = member.PhoneNumber
                }
            };
            return View(vm);
        }
        public async Task<IActionResult> MemberUpdate(MemberUpdate_VM memberVM)
        {
            if (!ModelState.IsValid)
            {
                Profile_VM vm = new Profile_VM
                {
                    Member = memberVM
                };
                return View("profile",vm);
            }
            AppUser member = await _userManager.FindByNameAsync(User.Identity.Name);
            member.FullName = memberVM.FullName;
            member.Email = memberVM.Email;
            member.UserName = memberVM.UserName;
            member.PhoneNumber = memberVM.Phone;

            var result =  await _userManager.UpdateAsync(member);
            if(!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    Profile_VM vm = new Profile_VM
                    {
                        Member = memberVM
                    };
                    return View("profile",vm);
                }
            }
            await _signInManager.SignInAsync(member, false);

            return RedirectToAction("profile");
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ResetPassword_VM resetPassword)
        {
            AppUser user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if(user == null) return View("Error");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            string url = Url.Action("verifytoken", "account", new { email = resetPassword.Email, token = token}, Request.Scheme);

            await _mailService.SendEmailAsync(new Email.MailRequest { ToEmail = user.Email, Subject = "Reset Password", Body = $"<a href={url}>Reset click</a>" });

            TempData["Message"] = "please Check Your Email..";

            return RedirectToAction("login");
        }
        public async Task<IActionResult> VerifyToken(string email, string token)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            if (await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token))
            {
                TempData["Email"] = email;
                TempData["Token"] = token;
                return RedirectToAction("resetpassword");
            }

            return View("Error");
        }
        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPassword_VM resetPassword)
        {
            AppUser user = await _userManager.FindByEmailAsync(resetPassword.Email);
            
            var result = await _userManager.ResetPasswordAsync(user,resetPassword.Token,resetPassword.Password);

            if (!result.Succeeded) return View("Error");

            return RedirectToAction("login");
        }
    }
}
