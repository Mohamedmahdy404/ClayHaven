using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Service.Identity
{
   public static class  IdentityErrorHandling
    {

        public static List<string> GetFriendlyErrors(this IdentityResult identityResult)
        {
            List<string> errorList = new List<string>();
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    switch (error.Code)
                    {
                        case "PasswordTooShort":
                            errorList.Add("Your password must be at least 8 characters long."); 
                            break;
                        case "DuplicateUserName":
                            errorList.Add("The username is already taken. Please choose another one."); 
                            break;
                        case "InvalidEmail":
                            errorList.Add("The email address provided is invalid."); 
                            break;
                        default:
                            errorList.Add($"{error.Code} : {error.Description}");
                            break;
                    }
                }
            }
            return errorList;
        }

        public static bool DisplayErrors(this IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    Console.WriteLine($"{error.Code} : {error.Description}");
                }

                return false;
            }

            return true;
        }


    }
}
