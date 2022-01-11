using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChipIn.Controller.Data;
using Npgsql;
using System.Data;
using Newtonsoft.Json;
using DatabaseOperations;
using ChipIn.Controller.Controllers;

namespace ChipIn.Controller.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ChipInControllerContext _context;
        private readonly ChipInControllerContext _EventContext;
        public UsersController(ChipInControllerContext context)
        {
            _context = context;
        }

        // Get /api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User_>>> GetUsers()
        {
            return await _context.User_.ToListAsync();
        }

        // GET: api/Users/GetbyName/{partname}
        [HttpGet("GetbyName/{partname}")]
        public async Task<ActionResult<IEnumerable<User_>>> GetUserPartName([FromRoute] string partname)
        {
            User_ user = new User_();
            user.Name_ = partname;
            var users = await _context.User_
                                .Where(u => u.Name_.Equals(partname))
                                .Include(u => u.members)
                                .Include(u => u.Events)
                                .ToListAsync();

            if (users == null)
            {
                return NotFound();
            }
            return users;
        }
        
        [HttpGet("GetAllUsEv/{id}")]
        public async Task<ActionResult<IEnumerable<User_>>> GetAllUserEvents([FromRoute] int id)
        {
            var users = await _context.User_
                                .Where(u => u.Id.Equals(id))
                                .Include(u => u.members)
                                .Include(u => u.Events)
                                .ToListAsync();

            if (users == null)
            {
                return NotFound();
            }
            return users;
        }
        
        // GET: api/Users/"GetbyId/5
        [HttpGet("GetbyId/{id}")]
        public async Task<ActionResult<IEnumerable<User_>>> GetUserPartId([FromRoute] int id)
        {
            var users = await _context.User_
                                .Where(u => u.Id.Equals(id))
                                .Include(u => u.members)
                                .Include(u => u.Events)
                                .ToListAsync();

            if (users == null)
            {
                return NotFound();
            }
            return users;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User_ @user)
        {
            if (id != @user.Id)
            {
                return BadRequest();
            }

            _context.Entry(@user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        /*
        public async Task<IActionResult> PutEventOnUser(int id, User_ @user)
        {
            if (user.Id == null || !UserExists(id))
            {
                return BadRequest();
            }
            _context

        }
        */


        // POST: api/Users

        [HttpPost]
        public async Task<ActionResult<User_>> PostUser([Bind("id,name_,email,phoneNumber,photo, members")] User_ @user)
        {

            _context.User_.Add(@user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }

            return CreatedAtAction("GetUsers", new { id = @user.Id }, @user);
        }

        // DELETE: api/Users/5



        private bool UserExists(int id)
        {
            return _context.User_.Any(u => u.Id == id);
        }
    }
}
