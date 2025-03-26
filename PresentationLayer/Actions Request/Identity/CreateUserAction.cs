using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Actions_Request.Identity
{
    public class CreateUserAction
    {
        [Required]
        [MaxLength(250)]
        public string UserName { set; get; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { set; get; }

        [Required]
        [DataType(DataType.Password)]
      //  [RegularExpression(@"^(?=.*[!@#$%^&*(),.?""{}|<>]).{8,}$", ErrorMessage = "Password must be at least 8 characters long and include at least one special character.")]
        public string password { get; set; }

        [Required]
        [Compare("password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { set; get; }

        [Required]
        public string PhoneNumber { set; get; }

        [Required]
        public string RoleName { set; get; }



    }
}
