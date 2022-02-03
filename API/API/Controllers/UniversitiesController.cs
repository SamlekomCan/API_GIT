using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : BasesController<University, UniversityRepository, int>
    {
        UniversityRepository universityRepository;
        public UniversitiesController(UniversityRepository universityRepository) : base(universityRepository)
        {
            this.universityRepository = universityRepository;
        }
        [Route("DeleteKey")]

        [HttpGet]
        public ActionResult DeleteKey(University key)
        {
            var result = universityRepository.DeleteKey(key);
            if (result != 1)
            {
                return StatusCode(400, new { status = HttpStatusCode.BadRequest, result, message = "ID TIDAK DITEMUKAN" });
            }
            return Ok(result);
        }
    }
}
