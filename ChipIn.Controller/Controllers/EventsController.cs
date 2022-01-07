using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChipIn.Controller.Data;
using ChipIn.models;
using System.Text.Json.Serialization;

namespace ChipIn.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ChipInControllerContext _context;

        public EventsController(ChipInControllerContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents(int id)
        {
            return null;
        }


        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent([FromRoute] int id)
        {
            var model = await _context.Event.FirstOrDefaultAsync(e =>
                 e.id == id
                               );

            if (model == null)
            {
                return NotFound();
            }
            
            return model;
        }
        // GET: api/Events/byName/someName
        [HttpGet("byName/{partname}")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventPartName([FromRoute] string partname)
        {
                
            return await _context.Event.; 
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.id)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent([Bind("Id,name_,deadline,creditorName,fullAmount")] Event @event)
        {            
            _context.Event.Add(@event);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }

            return CreatedAtAction("GetEvent", new { id = @event.id }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.id == id);
        }
    }
}
