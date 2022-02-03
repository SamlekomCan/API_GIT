using API.Context;
using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CEmployeesController : ControllerBase
    {
        private EmployeeRepository employeeRepository;

        public CEmployeesController(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpPost]
        public ActionResult Post(Employee emp)
        {

            var result = employeeRepository.Post(emp);
            if (result != 1)
            {
                if (result == 2)
                {
                    return StatusCode(400, new { status = HttpStatusCode.BadRequest, result, message = "NOMOR HP DAN EMAIL SUDAH TERPAKAI" });
                }
                else if (result == 3)
                {
                    return StatusCode(400, new { status = HttpStatusCode.BadRequest, result, message = "NOMOR HP SUDAH TERPAKAI" });
                }
                else if (result == 4)
                {
                    return StatusCode(400, new { status = HttpStatusCode.BadRequest, result, message = "EMAIL HP SUDAH TERPAKAI" });
                }
                return StatusCode(400, new { status = HttpStatusCode.BadRequest, result, message = "INSERT GAGAL" });
            }
            else
            {
                return Ok(new { status = HttpStatusCode.OK, message = "INSERT BERHASIL" });
            }
        }

        [HttpDelete]
        public ActionResult Delete(Employee emp)
        {
            var result = employeeRepository.Delete(emp.NIK);
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
        public ActionResult Put(Employee emp)
        {

            var result = employeeRepository.Put(emp);
            if (result > 0)
            {
                return Ok(new { status = HttpStatusCode.OK, result, message = "BERHASIL UPDATE" });
            }
            else
            {
                return StatusCode(400, new { status = HttpStatusCode.BadRequest, result, message = "GAGAL UPDATE, NIK TIDAK DITEMUKAN" });
            }
        }

        [HttpGet("{NIK}")]
        public ActionResult Get(Employee emp)
        {
            var result = employeeRepository.Get(emp.NIK);
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
            var result = employeeRepository.Get();
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








