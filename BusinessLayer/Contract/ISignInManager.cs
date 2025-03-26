using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Identity.User;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Contract
{
    public interface ISignInManager
    {
        public Task<List<string>> Register(CreateUserDto newUser);
        public Task<string> SignIn(SigninUserDto user);
        public Task SignOutAsync();

    }
}
