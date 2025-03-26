using BusinessLayer.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Actions_Request.Identity;
using PresentationLayer.Mapping;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;

namespace PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISignInManager _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(ISignInManager signInManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        #region LogIn

        [HttpGet]
        public  IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginAction userLoginAction)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginAction);
            }
            var error = await _signInManager.SignIn(userLoginAction.toSigninUserDto());

            if (error !=String.Empty)
               ModelState.AddModelError("", error);

            if (!ModelState.IsValid)
            {
                return View(userLoginAction);
            }

            if (User.IsInRole("Customer"))
            {
                return RedirectToAction("Index", "Order");

            }
            else
            {
                return RedirectToAction("Display", "Product");

            }
            //return View();
            //return RedirectToAction("Display", "Product");

        }
        #endregion


        #region Register

        
        [HttpGet]
        public async Task<IActionResult>  Register()
        {
            var rolesList = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            ViewBag.Roleslist = rolesList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserAction newUserAction)
        {
  
            if (!ModelState.IsValid)
            {
                return View(newUserAction); 
            }
            var errorList = await _signInManager.Register(newUserAction.ToCreateUserDto());

           
           foreach (var error in errorList)
           {
               ModelState.AddModelError("", error);
           }

           if (!ModelState.IsValid)
           {
               return View(newUserAction); 
           }

           if (User.IsInRole("Customer"))
           {
                return RedirectToAction("Index", "Order");

           }
           else
           {
                return RedirectToAction("Display", "Product");

           }


            //return RedirectToAction("Index", "Order");
        }

        #endregion


        #region SignOut

        public async Task<IActionResult> Signout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index","Home");
        }

        #endregion

    }
}
