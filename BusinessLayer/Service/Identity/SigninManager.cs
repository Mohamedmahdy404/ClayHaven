using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Contract;
using BusinessLayer.DTOs.Identity.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;


namespace BusinessLayer.Service.Identity
{
   public class SignInManager: ISignInManager
    {
       private readonly SignInManager<IdentityUser> _signInManager; 
       private readonly IUserManager _UserManager;


       public SignInManager(SignInManager<IdentityUser> signInManager, IUserManager userManager)
       {
           _signInManager = signInManager;
           _UserManager = userManager;
       }



       public async Task<string> SignIn(SigninUserDto user)
       {

            var result = await _UserManager.GetByEmail(user.Email);
           if (result == null)
               return "Cant Find Email";

           var result2 = await _signInManager.PasswordSignInAsync(result, user.Password, user.RememberMe, lockoutOnFailure: false);
           if (!result2.Succeeded)
               return "Wrong Password";

           return String.Empty;

       }

       

       public async Task<List<string>> Register(CreateUserDto newUser)
        {
          var errorList =await _UserManager.Create(newUser);
          if (errorList.IsNullOrEmpty())
          {
              var iResult = await _UserManager.AssignRole(newUser.Email, newUser.RoleName);
              if (!iResult.Succeeded)
              {

                  foreach (var e in iResult.Errors)
                  {
                      errorList.Add($"{e.Code} : {e.Description}");
                  }

                  return errorList;
              }
              var error=  await SignIn(new SigninUserDto()
              { 
                  Email = newUser.Email, 
                  Password = newUser.password
              });
              if (error != String.Empty)
                  errorList.Add(error);

              
          }
          return errorList;
       }


       public async Task SignOutAsync()
       {
           await _signInManager.SignOutAsync();
       }


    }
}
