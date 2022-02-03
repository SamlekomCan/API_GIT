//using API.Models;
//using API.Repository;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;

//namespace API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProfilingsController : ControllerBase
//    {
//        private ProfilingRepository profilingRepository;

//        public ProfilingsController(ProfilingRepository profilingRepository)
//        {
//            this.profilingRepository = profilingRepository;
//        }

//        [HttpPost]
//        public ActionResult Post(Profiling pro)
//        {
//            var result = profilingRepository.Post(pro);
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
//        public ActionResult Delete(Profiling acc)
//        {
//            var result = profilingRepository.Delete(acc.NIK);
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
//        public ActionResult Put(Profiling acc)
//        {

//            var result = profilingRepository.Put(acc);
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
//        public ActionResult Get(Profiling acc)
//        {
//            var result = profilingRepository.Get(acc.NIK);
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
//            var result = profilingRepository.Get();
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
