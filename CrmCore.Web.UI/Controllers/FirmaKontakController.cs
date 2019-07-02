using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CrmCore.Application.FirmaKontakServices;
using CrmCore.Application.FirmaKontakServices.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CrmCore.Web.UI.Controllers
{
    public class FirmaKontakController : Controller
    {
        private readonly IFirmaKontakService _firmaKontakService;

        public FirmaKontakController(IFirmaKontakService firmaKontakService)
        {
            _firmaKontakService = firmaKontakService;
        }

        public async Task<IActionResult> Index(int id)
        {
            //var list = await _firmaKontakService.GetAllByIdAsync(id);
            //ViewBag.FirmaKontakId = id;
            //return View(list);

            return View(await _firmaKontakService.GetAll());
            //string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //return View(await _firmaService.GetAllByOwner(userId));
        }

        public IActionResult Create(int id)
        {
            CreateFirmaKontak model = new CreateFirmaKontak();
            model.FirmaId = id;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(int id, CreateFirmaKontak model)
        {
            if (ModelState.IsValid)
            {
                model.CreatorUserId = "669521ad-0211-4851-8df7-7d8823c105d4";//User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var createdItem = await _firmaKontakService.CreateAsync(model);
                return RedirectToAction("Index", new { id = model.FirmaId });
            }
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var existItem = await _firmaKontakService.GetAsync(id);
            UpdateFirmaKontak model = new UpdateFirmaKontak
            {
                Id = existItem.Id,
                FirmaId = existItem.FirmaId,
                CreatorUserId = existItem.CreatorUserId,
                AdiSoyadi = existItem.AdiSoyadi,
                Telefon = existItem.Telefon,
                EPosta = existItem.EPosta
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateFirmaKontak model)
        {
            if (ModelState.IsValid)
            {
                var updated = await _firmaKontakService.UpdateAsync(model);
                UpdateFirmaKontak newModel = new UpdateFirmaKontak
                {
                    Id = updated.Id,
                    FirmaId = updated.FirmaId,
                    CreatorUserId = updated.CreatorUserId,
                    AdiSoyadi = updated.AdiSoyadi,
                    Telefon = updated.Telefon,
                    EPosta = updated.EPosta
                };
                return View(newModel);
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _firmaKontakService.GetAsync(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteFirmaKontak model)
        {
            if (ModelState.IsValid)
            {
                await _firmaKontakService.DeleteAsync(model.Id);
                return RedirectToAction("Index", new { id = model.FirmaId });
            }
            return RedirectToAction("Delete", new { id = model.Id });
        }
    }
}