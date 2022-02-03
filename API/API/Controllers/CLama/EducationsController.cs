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
//    public class EducationsController : ControllerBase
//    {
//        private EducationRepository educationRepository;

//        public EducationsController(EducationRepository educationRepository)
//        {
//            this.educationRepository = educationRepository;
//        }

//        [HttpPost]
//        public ActionResult Post(Education acc)
//        {
//            var result = educationRepository.Post(acc);
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
//        public ActionResult Delete(Education edu)
//        {
//            var result = educationRepository.Delete(edu.id);
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
//        public ActionResult Put(Education acc)
//        {
//            var result = educationRepository.Put(acc);
//            if (result > 0)
//            {
//                return Ok(new { status = HttpStatusCode.OK, result, message = "BERHASIL UPDATE" });
//            }
//            else
//            {
//                return StatusCode(400, new { status = HttpStatusCode.BadRequest, result, message = "GAGAL UPDATE" });
//            }
//        }

//        [HttpGet("{id}")]
//        public ActionResult Get(Education edu)
//        {
//            var result = educationRepository.Get(edu.id);
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
//            var result = educationRepository.Get();
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
