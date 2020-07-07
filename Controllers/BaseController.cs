using System.Data.Common;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookingTickets.Data;
//using System.Runtime.Intrinsics.Arm.Arm64;

namespace BookingTickets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TRepository> : Controller
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;

        public BaseController(TRepository repository){
            this._repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await _repository.GetAll();
        }
  
        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var data = await _repository.Get(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity data)
        {
            if (id != data.Id)
            {
                return BadRequest();
            }
            await _repository.Update(data);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity data)
        {
            await _repository.Add(data);
            return CreatedAtAction("Get", new { id = data.Id }, data);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var data = await _repository.Delete(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }

    }
}