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
        public ActionResult Create()
        {
            try
            {
                var result = new StudentDetails();
                return View("Create",result);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentDetails value)
        {
            try
            {
                _add.Insert(value);
                return RedirectToAction(nameof(Index));
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
    }
}
