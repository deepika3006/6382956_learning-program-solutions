using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FirstWebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static readonly List<string> Data = new() { "Item1", "Item2" };

        [HttpGet]
        public IActionResult GetAll() => Ok(Data);

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            if (id < 0 || id >= Data.Count) return NotFound();
            return Ok(Data[id]);
        }

        [HttpPost]
        public IActionResult Create([FromBody] string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return BadRequest("value required");
            Data.Add(value);
            return CreatedAtAction(nameof(GetById), new { id = Data.Count - 1 }, value);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] string value)
        {
            if (id < 0 || id >= Data.Count) return NotFound();
            Data[id] = value;
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= Data.Count) return NotFound();
            Data.RemoveAt(id);
            return NoContent();
        }
    }
}
