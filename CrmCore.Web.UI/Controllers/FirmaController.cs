using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CrmCore.Application;
using Microsoft.AspNetCore.Mvc;

namespace CrmCore.Web.UI.Controllers
{
    public class FirmaController : Controller
    {
        private readonly IFirmaService _firmaService;
        public FirmaController(IFirmaService firmaService)
        {
            _firmaService = firmaService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _firmaService.GetAll());
            //string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //return View(await _firmaService.GetAllByOwner(userId));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateFirma model)
        {
            if (ModelState.IsValid)
            {
                model.CreatorUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var newItem = await _firmaService.Create(model);
                return RedirectToAction("Index", "Firma");
            }
            return View();
        }

        public async Task<ActionResult> Delete(int id)
        {
            return View(await _firmaService.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(DeleteFirma model)
        {
            if (ModelState.IsValid)
            {
                await _firmaService.Delete(model.Id);
            }
            return RedirectToAction("Index", "Firma");
        }

        public async Task<ActionResult> Update(int id)
        {
            var model = await _firmaService.Get(id);
            UpdateFirma updateModel = new UpdateFirma
            {
                Id = id,
                Adi = model.Adi,
                CreatorUserId = model.CreatorUserId
            };
            return View(updateModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(UpdateFirma model)
        {
            if (ModelState.IsValid)
            {
                var updatedFirma = await _firmaService.Update(model);
                UpdateFirma updateModel = new UpdateFirma
                {
                    Id = updatedFirma.Id,
                    Adi = updatedFirma.Adi,
                    CreatorUserId = updatedFirma.CreatorUserId
                };
            }
            return View(model);
        }
    }
}