using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OCMS03.Data;
using OCMS03.Infrastructure;
using OCMS03.Models;
using OCMS03.Models.Content;
using OCMS03.Models.Repositories;
using static OCMS03.Infrastructure.Helper;

namespace OCMS03.Controllers
{
    public class ProvinceController : Controller
    {
        private readonly OCMS03_TheCollectiveContext _context;
        public ProvinceController(OCMS03_TheCollectiveContext contexts)
        {
            _context = contexts;
        }
        public IActionResult Index()
        {
            var model = _context.tblProvince;
            return View(model);
        }
        [NoDirectAccess]
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Province());
            else
            {
                var provinces = await _context.tblProvince.FindAsync(id);
                if (provinces == null)
                {
                    return NotFound();
                }
                return View(provinces);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("ProvinceId,ProvinceName")] Province provinces)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _context.Add(provinces);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    try
                    {
                        _context.Update(provinces);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProvinceModelExists(provinces.ProvinceId))
                        { 
                            return NotFound(); 
                        }
                        else
                        { 
                            throw; 
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.tblProvince.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", provinces) });
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var province = await _context.tblProvince.FindAsync(id);
            _context.tblProvince.Remove(province);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.tblProvince.ToList()) });
        }

        private bool ProvinceModelExists(int id)
        {
            return _context.tblProvince.Any(e => e.ProvinceId == id);
        }














        //[HttpGet]
        //public IActionResult Create()
        //{
        //    Province model = new Province();
        //    return PartialView("_AddProvinceModelPartial", model);
        //}
        //[HttpPost]
        //public IActionResult Create(Province model)
        //{
        //    context.Add(model);
        //    return RedirectToAction("Index", model);
        //}
        //public IActionResult Edit(int id)
        //{
        //    var province = context.GetProvince(id);
        //    return PartialView("_EditProvinceModelPartial", province);
        //}
        //[HttpPost]
        //public IActionResult Edit(Province province)
        //{
        //    context.Update(province);
        //    return RedirectToAction("Index", province);
        //}
        //[HttpGet]
        //public IActionResult Details(int id)
        //{
        //    var province = context.GetProvince(id);
        //    return PartialView("_DetailsProvinceModelPartial", province);
        //}
      
        //public IActionResult Delete(int id)
        //{
        //    var province = context.Delete(id);
        //    return PartialView("_DeleteDepartmentModelPartial", province);
        //}
    }
}
