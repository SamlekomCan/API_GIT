using API.Base;
using API.Context;
using API.Models;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BasesController<Employee, EmployeeRepository, string>
    {
        public EmployeeRepository employeeRepository;
        public EmployeesController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("TestCORS")]
        public ActionResult TestCORS()
        {
            return Ok("Test CORS BERHASIL");
        }

        [Route("Register")]
        [HttpPost]
        public ActionResult RegisterVM(RegisterVM reg)
        {
            var result = employeeRepository.RegisterVM(reg);
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
                    return StatusCode(400, new { status = HttpStatusCode.BadRequest, result, message = "EMAIL SUDAH TERPAKAI" });
                }
                return StatusCode(400, new { status = HttpStatusCode.BadRequest, result, message = "INSERT GAGAL" });
            }
            else
            {
                return Ok(new { status = HttpStatusCode.OK, message = "INSERT BERHASIL" });
            }
        }

        [Authorize(Roles = "Director, Manager")]
        [Route("GetRegisteredData")]
        [HttpGet]
        public ActionResult<RegisterVM> GetRegisteredData()
        {
            var result = employeeRepository.GetRegisteredData();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(400, new { status = HttpStatusCode.NotFound, result, message = "DATA TIDAK DITEMUKAN" });
            }
        }

    }
}
