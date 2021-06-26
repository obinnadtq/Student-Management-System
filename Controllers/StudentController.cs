using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController: Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Get Students
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            var students = _db.Student;

            return students;

        }
    }
}