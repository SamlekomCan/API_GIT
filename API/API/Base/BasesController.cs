using API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasesController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;

        public BasesController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<Entity> Get()
        {
            var result = repository.Get();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Entity> Post(Entity entity)
        {
            var result = repository.Post(entity);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<Entity> Put(Entity entity)
        {
            var result = repository.Put(entity);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult<Entity> Delete(Key key)
        {
            var result = repository.Delete(key);
            return Ok(result);
        }
    }
}
