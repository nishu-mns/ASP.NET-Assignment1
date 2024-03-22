using Assignment1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeysController : ControllerBase
    {
        private readonly KeyValueDbContext _dbContext;

        public KeysController(KeyValueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            var keyValue = await _dbContext.KeyValuePairs.FirstOrDefaultAsync(kv => kv.Key == key);
            if (keyValue != null)
            {
                return Ok(keyValue);
            }
            return NotFound();
        }

        [HttpPost]
        [HttpPut]
        public async Task<IActionResult> PostOrPut([FromBody] Models.KeyValuePair keyValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingKeyValue = await _dbContext.KeyValuePairs.FirstOrDefaultAsync(kv => kv.Key == keyValue.Key);
            if (existingKeyValue != null)
            {
                return Conflict();
            }

            _dbContext.KeyValuePairs.Add(keyValue);
            await _dbContext.SaveChangesAsync();
            return Ok(keyValue);
        }

        [HttpPatch("{key}/{value}")]
        public async Task<IActionResult> Patch(string key, string value)
        {
            var keyValue = await _dbContext.KeyValuePairs.FirstOrDefaultAsync(kv => kv.Key == key);
            if (keyValue != null)
            {
                keyValue.Value = value;
                await _dbContext.SaveChangesAsync();
                return Ok(keyValue);
            }
            return NotFound();
        }

        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            var keyValue = await _dbContext.KeyValuePairs.FirstOrDefaultAsync(kv => kv.Key == key);
            if (keyValue != null)
            {
                _dbContext.KeyValuePairs.Remove(keyValue);
                await _dbContext.SaveChangesAsync();
                return Ok(keyValue);
            }
            return NotFound();
        }
    }
}
