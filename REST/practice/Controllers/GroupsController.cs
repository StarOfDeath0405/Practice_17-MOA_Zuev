using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using practice.Models;

namespace practice.Controllers
{
    [Route("api/Groups")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly GroupsContext _context;
        public GroupsController(GroupsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetGroupss()
        {
            var Groupss = _context.Groups.ToList();
            return Ok(Groupss);
        }

        [HttpGet("{id}")]
        public IActionResult GetGroupssbyId(int id)
        {
            var Groups = _context.Groups.Find(id);
            if(Groups == null)
            {
                return NotFound();
            }
            return Ok(Groups);
        }

        [HttpPost("{name}")]
        public IActionResult PostGroups(string name)
        {
            var Groups = new Groups()
            {
                Group_Name = name
            };
            _context.Add(Groups);
            _context.SaveChanges();
            return Ok("Created");
        }

        [HttpPut("{id}/{rename}")]
        public IActionResult PutGroups(int id, string rename)
        {
            var Groups = _context.Groups.Find(id);
            if (Groups == null)
            {
                return NotFound();
            }
            Groups.Group_Name = rename;
            _context.Groups.Update(Groups);
            _context.SaveChanges();
            return Ok("Update");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGroups(int id)
        {
            var Groups = _context.Groups.Find(id);
            if (Groups == null)
            {
                return NotFound();
            }
            _context.Groups.Remove(Groups);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    } 
}

