using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Identity.Role;

namespace BusinessLayer.DTOs.Identity.User
{
  public  class DisplayUserData
    {
        public string Id { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public GetRoleData Role { set; get; } = new GetRoleData();

        // public List<GetRoleData> RolesList { set; get; } = new List<GetRoleData>();

    }
}
