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
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsContext _context;
        public StudentsController(StudentsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStudentss()
        {
            var Studentss = _context.Students.ToList();
            return Ok(Studentss);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentssbyId(int id)
        {
            var Students = _context.Students.Find(id);
            if (Students == null)
            {
                return NotFound();
            }
            return Ok(Students);
        }

        [HttpPost("{name}/{id}")]
        public IActionResult PostStudents(string name, int id)
        {
            var Students = new Students()
            {
                Student_Name = name,
                Group_Id = id
            };
            _context.Add(Students);
            _context.SaveChanges();
            return Ok("Created");
        }

        [HttpPut("{id}/{rename}/{id2}")]
        public IActionResult PutStudents(int id, string rename, int id2)
        {
            var Students = _context.Students.Find(id);
            if (Students == null)
            {
                return NotFound();
            }
            Students.Student_Name = rename;
            Students.Group_Id = id2;
            _context.Students.Update(Students);
            _context.SaveChanges();
            return Ok("Update");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudents(int id)
        {
            var Students = _context.Students.Find(id);
            if (Students == null)
            {
                return NotFound();
            }
            _context.Students.Remove(Students);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}

