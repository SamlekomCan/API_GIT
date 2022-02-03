using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class AccountRole
    {
        public virtual Account Accounts { get; set; }
        public string NIK { get; set; }
        public virtual Role Roles { get; set; }
        public int Role_Id { get; set; }
    }
}
