using API.Models;
using API.Repository;
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
    public class CUniversitiesController : ControllerBase
    {
        private UniversityRepository universityRepository;
        public CUniversitiesController(UniversityRepository universityRepository)
        {
            this.universityRepository = universityRepository;
        }

        [HttpPost]
        public ActionResult Post(University acc)
        {
            var result = universityRepository.Post(acc);
            if (result > 0)
            {
                return Ok(new { status = HttpStatusCode.OK, message = "BERHASIL DI INSERT" });
            }
            else
            {
                return StatusCode(400, new { status = HttpStatusCode.BadRequest, result, message = "GAGAL INSERT" });
            }
        }

        [HttpDelete]
        public ActionResult Delete(University uni)
        {
            var result = universityRepository.Delete(uni.id);
            if (result > 0)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "BERHASIL DI DELETE" });
            }
            else
            {
                return StatusCode(400, new { status = HttpStatusCode.BadRequest, result, message = "DATA TIDAK DITEMUKAN" });
            }
        }

        [HttpPut]
        public ActionResult Put(University uni)
        {
            var result = universityRepository.Put(uni);
            if (result > 0)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "BERHASIL UPDATE" });
            }
            else
            {
                return StatusCode(400, new { status = HttpStatusCode.BadRequest, result, message = "GAGAL UPDATE" });
            }
        }

        [HttpGet("{NIK}")]
        public ActionResult Get(University uni)
        {
            var result = universityRepository.Get(uni.id);
            if (result != null)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "DATA DITEMUKAN" });
            }
            else
            {
                return StatusCode(404, new { status = HttpStatusCode.NotFound, result, message = "DATA TIDAK DITEMUKAN" });
            }
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = universityRepository.Get();
            if (result == null)
            {
                return StatusCode(404, new { status = HttpStatusCode.NotFound, result, message = "DATA KOSONG" });
            }
            else
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "DATA DITAMPILKAN" });
            }
        }
    }
}
