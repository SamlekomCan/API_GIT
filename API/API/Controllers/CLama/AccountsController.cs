//using API.Context;
//using API.Models;
//using API.Repository;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Linq;
//using System.Net;

//namespace API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]

//    public class AccountsController : ControllerBase
//    {
//        private AccountRepository accountRepository;

//        public AccountsController(AccountRepository accountRepository)
//        {
//            this.accountRepository = accountRepository;
//        }

//        [HttpPost]
//        public ActionResult Post(Account acc)
//        {
//            var result = accountRepository.Post(acc);
//            if (result > 0)
//            {
//                return Ok(new { status = HttpStatusCode.OK, message = "BERHASIL DI INSERT" });
//            }
//            else
//            {
//                return StatusCode(400, new { status = HttpStatusCode.BadRequest, result, message = "GAGAL INSERT" });
//            }
//        }

//        [HttpDelete]
//        public ActionResult Delete(Account acc)
//        {
//            var result = accountRepository.Delete(acc.NIK);
//            if (result > 0)
//            {
//                return Ok(new { status = HttpStatusCode.OK, result, message = "BERHASIL DI DELETE" });
//            }
//            else
//            {
//                return StatusCode(400, new { status = HttpStatusCode.BadRequest, result, message = "DATA TIDAK DITEMUKAN" });
//            }
//        }

//        [HttpPut]
//        public ActionResult Put(Account acc)
//        {
//            var result = accountRepository.Put(acc);
//            if (result > 0)
//            {
//                return Ok(new { status = HttpStatusCode.OK, result, message = "BERHASIL UPDATE" });
//            }
//            else
//            {
//                return StatusCode(400, new { status = HttpStatusCode.BadRequest, result, message = "GAGAL UPDATE" });
//            }
//        }

//        [HttpGet("{NIK}")]
//        public ActionResult Get(Account acc)
//        {
//            var result = accountRepository.Get(acc.NIK);
//            if (result != null)
//            {
//                return Ok(new { status = HttpStatusCode.OK, result, message = "DATA DITEMUKAN" });
//            }
//            else
//            {
//                return StatusCode(404, new { status = HttpStatusCode.NotFound, result, message = "DATA TIDAK DITEMUKAN" });
//            }
//        }

//        [HttpGet]
//        public ActionResult Get()
//        {
//            var result = accountRepository.Get();
//            if (result == null)
//            {
//                return StatusCode(404, new { status = HttpStatusCode.NotFound, result, message = "DATA KOSONG" });
//            }
//            else
//            {
//                return Ok(new { status = HttpStatusCode.OK, result, message = "DATA DITAMPILKAN" });
//            }
//        }
//    }
//}
