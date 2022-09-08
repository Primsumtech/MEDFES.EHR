using System;
using System.Collections.Generic;

namespace Domains.Entities
{
    public partial class Users
    {
        public int userid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string middlename { get; set; }

        public string mobileno{ get; set; }
        public string address1 { get; set; }
        //public string address2 { get; set; }
        //public DateTime dateofbirth { get; set; }

    }
}
