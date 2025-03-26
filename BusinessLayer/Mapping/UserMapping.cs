using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Identity.User;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Mapping
{
   public static class UserMapping
   {
       public static IdentityUser CreateUserDtoToIdentityUser(this CreateUserDto userDto)
       {
           return new IdentityUser()
           {
               UserName = userDto.UserName,
               Email = userDto.Email,
               PhoneNumber = userDto.PhoneNumber,
           };
       }

       public static DisplayUserData IdentityUserToDisplayUserData(this IdentityUser user)
       {
           return new DisplayUserData()
           {
               Id = user.Id,
               Email = user.Email,
               PhoneNumber = user.PhoneNumber,
               UserName = user.UserName
           };

       }

    }
}
