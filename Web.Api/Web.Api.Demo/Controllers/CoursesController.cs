using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Demo.Controllers
{
    public class CoursesController:ControllerBase
    {

        private readonly Repository _repository;
        private readonly IConfiguration _configuration;

        public CoursesController(Repository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }


        [HttpGet]
        public List<Course> GetCourses()
        {
            List<Course> courses = _repository.GetAllCourses();

            return courses;
        }
    }
}
