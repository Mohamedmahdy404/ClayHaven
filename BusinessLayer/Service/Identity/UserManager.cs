using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Contract;
using BusinessLayer.DTOs.Identity.Role;
using BusinessLayer.DTOs.Identity.User;
using BusinessLayer.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Service.Identity
{
  public  class UserManager: IUserManager
  {
      private readonly UserManager<IdentityUser> _userManager;

      public UserManager(UserManager<IdentityUser> userManager)
      {
          _userManager = userManager;
      }

      public async Task<List<string>> Create(CreateUserDto user)
      {
       var result = await   _userManager.CreateAsync(user.CreateUserDtoToIdentityUser(), user.password);


       return result.GetFriendlyErrors();
            
      }

        public async Task<bool> UpdatePassword(string id, string oldPassword,string newPassword)
        { 
            var user = await _userManager.FindByIdAsync(id);
           var result= await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
           return result.DisplayErrors();
        }

        public async Task<IdentityUser?> GetByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> CheckPassword(IdentityUser user, string password)
        {

            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<bool> Delete(string id)
        {
           var user= await _userManager.FindByIdAsync(id);
           var result= await _userManager.DeleteAsync(user);
           return result.DisplayErrors();
        }

        public async Task<List<DisplayUserData>> DisplayAllUserData(RoleManager<IdentityRole> roleManager)
        {
            IdentityRole identityRole=new IdentityRole();
            List<DisplayUserData> userData = new List<DisplayUserData>();

           var identityUsers =await _userManager.Users.ToListAsync();
           var users = identityUsers.Select(i => i.IdentityUserToDisplayUserData()).ToList();

           foreach (var identityUser in identityUsers)
           {
                var roleName = await _userManager.GetRolesAsync(identityUser);

                var role = roleName.FirstOrDefault();
                if (role != null)
                {
                     identityRole = await roleManager.FindByNameAsync(role);

                }
                userData.Add(new DisplayUserData()
                {
                    Id = identityUser.Id,
                    Email = identityUser.Email,
                    PhoneNumber = identityUser.PhoneNumber,
                    UserName = identityUser.UserName,
                    Role = new GetRoleData()
                    {
                        Id = identityRole.Id,
                        RoleName = identityRole.Name
                    }

                });
               
           }

           return userData;

        }

        public async Task<IdentityResult> AssignRole(string email, string role)
        {

           return await _userManager.AddToRoleAsync( await GetByEmail(email) , role);

        }

    }
}
