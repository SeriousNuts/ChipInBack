using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChipIn.Controller.Data;
using ChipIn.models;
using Npgsql;
using System.Data;
using Newtonsoft.Json;
using DatabaseOperations;

namespace ChipIn.Controller.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        


        private IUserRepository users = new UserRepository();


        // GET: api/Users/{partname}
        [HttpGet("/{partname}")]
        public List<String> GetUsersByPartName(String partName)
        {
            GetDataFromDB dboperations = new GetDataFromDB();//самописный класс лежит в папке из database

            string sqlreq = @"select name_ as ""Name"", email as ""Email"", phonenumber as ""PhoneNumber"", photo as ""Photo"" from public.user_ where ""name_"" like '" + partName + "'";
            
            return dboperations.getStringsFromDB(sqlreq);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public string GetUser(int id)
        {
            string sqlreq = @"select name_ as ""Name"", email as ""Email"", phonenumber as ""PhoneNumber"", photo as ""Photo"" from public.user_ where ""id_"" = " + id.ToString();
            
            GetDataFromDB dboperations = new GetDataFromDB();//самописный класс лежит в папке из database
         
            return dboperations.getOneStringFromDB(sqlreq);
        }

        // PUT: api/Users/5
        
       
       

        // POST: api/Users
        
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
           

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
       

        
    }
}
