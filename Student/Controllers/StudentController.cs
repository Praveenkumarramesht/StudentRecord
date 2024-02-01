using EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentsRepository _add;
        private readonly string _connectionstring;
        public StudentController(IStudentsRepository add, IConfiguration configuration)
        {
            _add = add;
            _connectionstring = configuration.GetConnectionString("DbConnection");
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var result = _add.GetAllDetails();
            return View("List",result);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = _add.GetbyID(id);
                return View();
            }
            catch
            {
                return View("Error");
            }
           
        }

        // GET: StudentController/Create
        public ActionResult Create(long? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var student = _add.GetbyID(id.Value);
                    return View("Create", student);
                }
                else
                {
                    var result = new StudentDetails();
                    result.Gender = "M";
                    return View("Create", result);
                }
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: StudentController/Creates
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Creates(StudentDetails value)
        {
            try
            {

                if (value.StudentID == 0)
                {
                    _add.Insert(value);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _add.Update(value.StudentID,value);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var result = _add.GetbyID(id);
                return View("Edit", result);
            }
            catch
            {
                return View("Error");
            }
           
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentDetails value)
        {
            try
            {
                _add.Update(id, value);
                var result = _add.GetAllDetails();
                return View("View",result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _add.GetbyID(id);
                return View("View", result);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private List<Subject> Getvalue()
        {
            try
            {
                List<Subject> Course = new List<Subject>();
                Subject input = new Subject();
                input.id = 1;
                input.Subjects = "Tamil";
                Subject input1 = new Subject();
                input1.id = 2;
                input1.Subjects = "Math";
                Subject input2 = new Subject();
                input2.id = 3;
                input2.Subjects = "English";
                Course.Add(input);
                Course.Add(input1);
                Course.Add(input2);
                return Course;

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("~/api/Course")]
        public ActionResult Subjectlist()
        {
            try
            {
                var get = Getvalue();
                return Ok(get);
            }
            catch
            {
                throw;
            }
        }
    }
}
