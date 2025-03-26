using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Identity.User;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Contract
{
    public interface IUserManager
    {
        public Task<List<string>> Create(CreateUserDto user);
        public Task<bool> UpdatePassword(string id, string oldPassword, string newPassword);
        public Task<IdentityUser?> GetByEmail(string email);
        public Task<bool> CheckPassword(IdentityUser user, string password);
        public Task<bool> Delete(string id);
        public  Task<List<DisplayUserData>> DisplayAllUserData(RoleManager<IdentityRole> roleManager);
        public  Task<IdentityResult> AssignRole(string email, string role);

    }
}
