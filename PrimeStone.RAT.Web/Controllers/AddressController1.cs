using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimeStone.RAT.Common.Interface;
using PrimeStone.RAT.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeStone.RAT.Web.Controllers
{
    public class AddressController1 : Controller
    {
        private readonly IAddressService _service;
        private readonly ILogger<AddressController1> _logger;

        public AddressController1(IAddressService service, ILogger<AddressController1> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: AddressController1
        public async Task<ActionResult> Index()
        {
            List<AddressDto> lista = new List<AddressDto>();
            try
            {
                lista = await _service.ListAddresses();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return View(lista);
        }

        // GET: AddressController1/Details/5
        public ActionResult Details(int id)
        {
            var entity = _service.GetAddress(id);
            if (entity == null)
                return NotFound();

            return View(entity);
        }

        // GET: AddressController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddressController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressDto collection)
        {
            try
            {
                _service.AddAddress(collection, User.Identity.Name);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: AddressController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AddressController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AddressDto collection)
        {
            try
            {
                _service.UpdateAddress(collection, User.Identity.Name);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AddressController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddressController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _service.DeleteAddress(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
