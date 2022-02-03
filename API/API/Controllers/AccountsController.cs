using API.Base;
using API.Context;
using API.Models;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BasesController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;
        public IConfiguration _configuration;
        public MyContext context;
        public AccountsController(AccountRepository accountRepository, IConfiguration configuration, MyContext context) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this._configuration = configuration;
            this.context = context;
        }
        [HttpGet("{Login}")]
        public ActionResult<AccountVM> Login(AccountVM acc)
        {
            var result = accountRepository.Login(acc);
            if (result != 1)
            {
                return StatusCode(400, new { status = HttpStatusCode.NotFound, result, message = "ACCOUNT TIDAK DITEMUKAN" });
            }
            else
            {
                var getUserData = context.Employees.Where(e => e.Email == acc.Email
                || e.Phone == acc.Phone).FirstOrDefault();
                //var account = context.Accounts.Where(a => a.NIK == getUserData.NIK).FirstOrDefault();
                var role = context.Role.Where(a => a.AccountRoles.Any(ar => ar.Accounts.NIK == getUserData.NIK)).ToList();

                var claims = new List<Claim>
                {
                    new Claim("Email", getUserData.Email)
                    //new Claim("roles", rName.ToString())
                };
                foreach (var roleName in role)
                {
                    claims.Add(new Claim("roles", roleName.RoleName));
                }
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn
                    );
                var idtoken = new JwtSecurityTokenHandler().WriteToken(token);
                claims.Add(new Claim("TokenSecurity", idtoken.ToString()));
                var re = accountRepository.profile(acc);
                return Ok(new { status = HttpStatusCode.OK, idtoken, message = "Login Success!" });
            }
        }

        //public ActionResult Profile(string email)
        //{
        //    var result = accountRepository.profile(email);
        //    if (result == null)
        //    {
        //        return StatusCode(400, new { status = HttpStatusCode.NotFound, result, message = "DATA TIDAK DITEMUKAN" });
        //    }
        //    else
        //    {
        //        return Ok(result);
        //    }
        //}

        [Route("Forgot")]
        [HttpPut("{Forgot}")]
        public ActionResult ForgotPassword(AccountVM acc)
        {
            var result = accountRepository.ForgotPassword(acc);
            if (result != 1)
            {
                return StatusCode(400, new { status = HttpStatusCode.NotFound, result, message = "ACCOUNT TIDAK DITEMUKAN" });
            }
            else
            {
                return Ok(result);
            }
        }
        [Route("changePass")]
        [HttpPut("{changePass}")]
        public ActionResult changePass(AccountVM acc)
        {
            var result = accountRepository.ChangePassword(acc);
            if (result == 2)
            {
                return StatusCode(400, new { status = HttpStatusCode.OK, result, message = "OTP EXPIRED" });
            }
            else if (result == 3)
            {
                return StatusCode(400, new { status = HttpStatusCode.OK, result, message = "OTP INVALID" });
            }
            else if (result == 4)
            {
                return StatusCode(400, new { status = HttpStatusCode.OK, result, message = "PASSWORD TIDAK SAMA" });
            }
            else if (result == 5)
            {
                return StatusCode(400, new { status = HttpStatusCode.OK, result, message = "OTP SUDAH TERPAKAI" });
            }
            else
            {
                return StatusCode(200, new { status = HttpStatusCode.OK, result, message = "CHANGE PASSWORD CONFIRM" });
            }
        }

        [Authorize]
        [HttpGet("TestJwt")]
        public ActionResult TestJwt()
        {
            return Ok("TEST JWT BERHASIL");
        }
    }
}
