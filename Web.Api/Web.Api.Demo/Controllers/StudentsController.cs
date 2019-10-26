using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.Models;

namespace Web.Api.Demo.Controllers
{

    public class StudentsController : ControllerBase
    {
        private readonly Repository _repository;
        private readonly IConfiguration _configuration;

        public StudentsController(Repository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _repository.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        public ActionResult<Student> DeleteStudentById(int id)
        {
            _repository.DeleteStudent(id);
            return GetStudentById(id - 1);
        }

        public ActionResult<Student> CreateStudent()
        {
            var _student = new Student() { Name = "created", BirthDate = DateTime.Now, PhoneNumber = "0939393939", Email = "paster@gsmadma.com" };
            _repository.CreateStudent(_student);
            return _student;
        }

        public ActionResult<Student> UpdateStudent(int id)
        {
            var student = _repository.GetStudentById(id);
            student.Name = "UpdatedName";
            return student;
        }

        [HttpPost]
        public string Update([FromBody]Student student)
        {
            return "ok";
        }
    }
}
