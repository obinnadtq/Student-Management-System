using System;
using System.Collections.Generic;
using System.Linq;
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

        // Get Student
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(Guid id)
        {
            var obj = _db.Student.Find(id);

            if(obj == null){
               return NotFound(); 
            }

            return obj;
        }

       [HttpPost] 
        public ActionResult<Student> CreateStudent(CreateNewStudent newStudent)
        {
            Student student = new Student(){
                Id = Guid.NewGuid(),
                FirstName = newStudent.FirstName,
                LastName = newStudent.LastName,
                MatricNo = newStudent.MatricNo,
                StateOfOrigin = newStudent.StateOfOrigin,
                Nationality = newStudent.Nationality,
                Age = newStudent.Age

            };
           _db.Student.Add(student);
           _db.SaveChanges();

           return CreatedAtAction(nameof(GetStudent), new {id = student.Id}, student);
        } 

        // PUT Students
        [HttpPut("{id}")]
        public ActionResult<Student> UpdateStudent(Guid id, UpdateStudent student)
        {
            var existingStudent = _db.Student.Find(id);

            if(existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.MatricNo = student.MatricNo;
            existingStudent.Nationality = student.Nationality;
            existingStudent.StateOfOrigin = student.Nationality;
            existingStudent.Age = student.Age;

            _db.Update(existingStudent);
            _db.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(Guid id)
        {
           var existingStudent = _db.Student.Find(id);

           if(existingStudent == null)
           {
               return NotFound();
           }

           _db.Student.Remove(existingStudent);
           _db.SaveChanges();

           return NoContent();
 
        }
    }
}