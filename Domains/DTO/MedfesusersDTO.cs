using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.DTO
{
    public class MedfesusersDTO
    {
        public int userid { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }

        public string mobileno { get; set; }

        public string Email { get; set; }
        public int RoleId { get; set; }
        public byte[] Passwordhash { get; set; }
        public byte[] Passwordsalt { get; set; }
    }

}
