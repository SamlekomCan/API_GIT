using API.Base;
using API.Context;
using API.Models;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountRolesController : BasesController<AccountRole, AccountRoleRepository, string>
    {
        private readonly AccountRoleRepository accountRoleRepository;
        public MyContext context;
        public AccountRolesController(AccountRoleRepository accountRoleRepository, MyContext context) : base(accountRoleRepository)
        {
            this.accountRoleRepository = accountRoleRepository;
            this.context = context;
        }

        [Authorize(Roles = "Director")]
        [HttpPost("SignManager")]
        public ActionResult<AccountVM> signManager(AccountVM acc)
        {
            var result = accountRoleRepository.signManager(acc);
            return Ok(new { status = HttpStatusCode.OK, result, message = "MANAGER HAS BEEN REGISTERED" });
        }
    }
}
