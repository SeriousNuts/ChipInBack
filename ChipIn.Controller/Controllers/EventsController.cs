using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChipIn.Controller.Data;
using ChipIn.Controller.Models;
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
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Event.Include(e => e.members).ToListAsync();
        }


        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent([FromRoute] int id)
        {
            var model = await _context.Event.Include(e => e.members).FirstOrDefaultAsync(e =>
                 e.id == id
                               );

            if (model == null)
            {
                return NotFound();
            }
            
            return model;
        }

        // GET: api/Events/EventsBy/someName
        [HttpGet("EventsBy/{partname}")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventPartName([FromRoute] string partname)
        {

            var events = await _context.Event
                                .Where(e => e.CreditorName.Equals(partname))
                                .Include(e => e.members)
                                .ToListAsync();
                                    
            if (events == null)
            {
                return NotFound();
            }
            return events;
        }
        [HttpGet("GetAllUsEv/{id}")]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllUserEvents([FromRoute] int id)
        {
            var events = await _context.Event
                                .Include(u => u.members)
                                .ToListAsync();
            List<Event>EventsM = new List<Event>();
            
            
            if (events == null)
            {
                return NotFound();
            }

            foreach (var e in events)
            {
                foreach (var m in e.members)
                {
                    if (m.UserId == id)
                    {
                        EventsM.Add(e);
                    }
                }
            }
            if (EventsM.Count == 0)
            {
                return NotFound();
            }

            return EventsM;
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
        public async Task<ActionResult<Event>> PostEvent([Bind("id,name_,deadline,creditorName,fullAmount, members")] Event @event)
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

        // DELETE: api/Events/deleteEvent/2
        [HttpDelete("deleteEvent/{id}")]
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
