using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Role
    {
        [Key]
        public int id { get; set; }
        public string RoleName
        {
            get; set;
        }
        public virtual ICollection<AccountRole> AccountRoles { get; set; }
    }
}
