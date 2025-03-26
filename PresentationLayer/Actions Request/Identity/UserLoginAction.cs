using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Actions_Request.Identity
{
    public class UserLoginAction
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; } 
    }
}
