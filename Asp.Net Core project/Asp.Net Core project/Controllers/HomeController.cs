using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Core_project.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core_project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly Repository repository;

        private readonly UserManager<IdentityUser> userManager;

        private readonly SignInManager<IdentityUser> signInManager;

        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(Repository repository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;

            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetStudentsId(int id)
        {
            return View(repository.GetStudentById(id));
        }

        public IActionResult GetStudents()
        {
            return View(repository.GetAllStudents());
        }

        public IActionResult GetCourses()
        {
            return View(repository.GetAllCourses());
        }

        public IActionResult GetLecturers()
        {
            return View(repository.GetAllLecturers());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddStudent(Student student)
        {
            repository.CreateStudent(student);
            return RedirectToAction("GetStudents");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditStudent(int id)
        {
            return View(repository.GetStudentById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditStudent(Student student, int id)
        {
            repository.UpdateStudent(student);
            return RedirectToAction("GetStudents");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteStudent(int id)
        {
            var student = repository.GetStudentById(id);
            return View(student);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteStudent(int id, Student student)
        {
            repository.DeleteStudent(id);
            return RedirectToAction("GetStudents");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCourse(Course course)
        {
            repository.CreateCourse(course);
            return RedirectToAction("GetCourses");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditCourse(int id)
        {
            return View(repository.GetCourse(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditCourse(Course course, int id)
        {
            repository.UpdateCourse(course);
            return RedirectToAction("GetCourses");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCourse(int id)
        {
            var course = repository.GetCourse(id);
            return View(course);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCourse(int id, Course course)
        {
            repository.DeleteCourse(id);
            return RedirectToAction("GetCourses");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddLecturer()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddLecturer(Lecturer lecturer)
        {
            repository.CreateLecturer(lecturer);
            return RedirectToAction("GetLecturers");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditLecturer(int id)
        {
            return View(repository.GetLecturerById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditLecturer(Lecturer lecturer, int id)
        {
            repository.UpdateLecturer(lecturer);
            return RedirectToAction("GetLecturers");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteLecturer(int id)
        {
            var lecturer = repository.GetLecturerById(id);
            return View(lecturer);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteLecturer(int id, Lecturer lecturer)
        {
            repository.DeleteLecturer(id);
            return RedirectToAction("GetLecturers");
        }

        //ASSIGN STUDENT
        //[HttpGet]
        //public IActionResult AssignStudents(int id)
        //{ 
        //    var allStudents = this.repository.GetAllStudents();
        //    var course = this.repository.GetCourse(id);
        //    CourseStudentAssignmentViewModel model = new CourseStudentAssignmentViewModel();

        //    model.Id = id;
        //    model.EndDate = course.EndDate;
        //    model.Name = course.Name;
        //    model.StartDate = course.StartDate;
        //    model.PassCredits = course.PassCredits;
        //    model.Students = new List<StudentViewModel>();

        //    foreach (var student in allStudents)
        //    {
        //        bool isAssigned = course.Students.Any(p => p.StudentId == student.Id);
        //        model.Students.Add(new StudentViewModel() { StudentId = student.Id, StudentFullName = student.Name, IsAssigned = isAssigned });
        //    }

        //    return this.View(model);
        //}

        //[HttpPost]
        //public IActionResult AssignStudents(CourseStudentAssignmentViewModel assignmentViewModel)
        //{
        //    this.repository.SetStudentsToCourse(assignmentViewModel.Id, assignmentViewModel.Students.Where(p => p.IsAssigned).Select(student => student.StudentId));

        //    return RedirectToAction("Courses");
        //}

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                await signInManager.SignOutAsync();
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
         

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> Users()
        {

            UsersViewModel model = new UsersViewModel() { UserNames = this.userManager.Users.Select(p => p.Email).ToList() };
            return this.View(model);
        }

    }
}
