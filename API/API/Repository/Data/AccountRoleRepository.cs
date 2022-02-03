using API.Context;
using API.Models;
using API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class AccountRoleRepository : GeneralRepository<MyContext, AccountRole, string>
    {
        private readonly MyContext context;
        public AccountRoleRepository(MyContext myContext) : base(myContext)
        {
            this.context = myContext;
        }
        public int signManager(AccountVM acc)
        {
            var getEmp = context.Employees.Where(e => e.NIK == acc.NIK).FirstOrDefault();
            var role = new AccountRole()
            {
                NIK = getEmp.NIK,
                Role_Id = 2
            };
            context.AccountRoles.Add(role);
            var result = context.SaveChanges();
            return result;
        }
    }
}
