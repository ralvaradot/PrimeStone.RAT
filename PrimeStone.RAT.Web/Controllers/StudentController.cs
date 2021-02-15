using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimeStone.RAT.Common.Interface;
using PrimeStone.RAT.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeStone.RAT.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService service, ILogger<StudentController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: StudentController1
        public async Task<ActionResult> Index()
        {
            List<StudentDto> lista = new List<StudentDto>();
            try
            {
                lista = await _service.ListStudentss();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return View(lista);
        }

        // GET: StudentController1/Details/5
        public ActionResult Details(int id)
        {
            var entity = _service.GetStudent(id);
            if (entity == null)
                return NotFound();

            return View(entity);
        }

        // GET: StudentController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentDto collection)
        {
            try
            {
                _service.AddStudent(collection, User.Identity.Name);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: StudentController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentDto collection)
        {
            try
            {
                _service.UpdateStudent(collection, User.Identity.Name);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _service.DeleteStudent(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
