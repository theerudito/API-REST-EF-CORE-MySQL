using EF_MySQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_MySQL.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class NarutoController : Controller
    {
        private readonly ApplicationDBContext context;

        public NarutoController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetAll()
        {
            return await context.Naruto.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetOneById(int id)
        {
            return await context.Naruto.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Character character)
        {
            context.Naruto.Add(character);
            await context.SaveChangesAsync();
            return Ok(character);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] Character character, int id)
        {
            if (character.Id != id)
            {
                return BadRequest();
            }

            context.Entry(character).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(character);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var character = await context.Naruto.FirstOrDefaultAsync(x => x.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            context.Naruto.Remove(character);
            await context.SaveChangesAsync();
            return Ok("");
        }
    }
}
