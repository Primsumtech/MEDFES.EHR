using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Entities.Users
{
    public class UserLoginEntity
    {
        public string Token { get; set; }
        public UserEntity User { get; set; }
        public RoleEntity Role { get; set; }
    }
}
