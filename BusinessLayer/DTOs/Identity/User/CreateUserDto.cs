using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Identity.User
{
public class CreateUserDto
    {
        public string UserName { set; get; }
        public string Email { set; get; }
        public string password { set; get; }
        public string PhoneNumber { set; get; }
        public string RoleName { set; get; }

    }
}
