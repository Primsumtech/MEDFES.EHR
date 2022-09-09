using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domains.Entities.MedfesUsers
{
    internal class Medfesuser
    {
        [Required]
        [StringLength(30)]
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }

        [Required]
        [StringLength(10)]
        public string mobilenumber { get; set; }

    }
}
