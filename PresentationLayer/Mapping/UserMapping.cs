using BusinessLayer.DTOs.Identity.User;
using PresentationLayer.Actions_Request.Identity;

namespace PresentationLayer.Mapping
{
    public static class UserMapping
    {
        public static SigninUserDto toSigninUserDto(this UserLoginAction user)
        {
            return new SigninUserDto()
            {
                Email = user.Email,
                Password = user.Password,
                RememberMe = user.RememberMe
                
            };
        }


        public static CreateUserDto ToCreateUserDto(this CreateUserAction user)
        {
            return new CreateUserDto()
            {
                Email = user.Email,
                password = user.password,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                RoleName = user.RoleName
            };
        }


    }
}
