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
    public class CursoController : Controller
    {
        private readonly ICursoService _service;
        private readonly ILogger<CursoController> _logger;

        public CursoController(ICursoService service, ILogger<CursoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: CursoController1
        public async Task<ActionResult> Index()
        {
            List<CursoDto> lista = new List<CursoDto>();
            try
            {
                lista = await _service.ListCursos();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return View(lista);
        }

        // GET: CursoController1/Details/5
        public ActionResult Details(int id)
        {
            var entity = _service.GetCurso(id);
            if (entity == null)
                return NotFound();

            return View(entity);
        }

        // GET: CursoController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CursoController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CursoDto collection)
        {

            try
            {
                _service.AddCurso(collection, User.Identity.Name);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: CursoController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CursoController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CursoDto collection)
        {
            try
            {
                _service.UpdateCurso(collection, User.Identity.Name);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CursoController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CursoController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _service.DeleteCurso(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
