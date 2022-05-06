using Juan_Back_End_Final.DAL;
using Juan_Back_End_Final.Extensions;
using Juan_Back_End_Final.Helpers;
using Juan_Back_End_Final.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Juan_Back_End_Final.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ServiceOfferController : Controller
    {
        private readonly JuanDbContext _context;
        private readonly IWebHostEnvironment _env;


        public ServiceOfferController(JuanDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<ServiceOffer> serviceOffers = await _context.ServiceOffers
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)serviceOffers.Count() / 5);

            return View(serviceOffers.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            ServiceOffer serviceOffer = await _context.ServiceOffers.FirstOrDefaultAsync(s => s.Id == id);

            if (serviceOffer == null) return NotFound();

            return View(serviceOffer);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.ServiceOffer = await _context.ServiceOffers.Where(c => !c.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceOffer serviceOffer, bool? status, int page = 1)
        {
            ViewBag.ServiceOffer = await _context.ServiceOffers.Where(s => !s.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            serviceOffer.Title = serviceOffer.Title.Trim();
            serviceOffer.Description = serviceOffer.Title.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(serviceOffer.Title) && regex.IsMatch(serviceOffer.Description))
            {
                ModelState.AddModelError("Name", "Should not be Space");
                ModelState.AddModelError("Description", "Should not be Space");
                return View();
            }

            for (int i = 0; i < serviceOffer.BgColor.Length; i++)
            {
                if (serviceOffer.BgColor[i] == ' ')
                {
                    ModelState.AddModelError("BgColor", "Should not be Space");
                    return View();
                }
            }

            if (serviceOffer.LogoImage == null)
            {
                ModelState.AddModelError("LogoImage", "Image Must be chosen!");
                return View();
            }
            else
            {
                if (!serviceOffer.LogoImage.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("LogoImage", "Image type must be in PNG format!");
                    return View();
                }

                if (!serviceOffer.LogoImage.CheckFileSize(30))
                {
                    ModelState.AddModelError("LogoImage", "Image size must be a maximum of 30KB!");
                    return View();
                }
                serviceOffer.Image = serviceOffer.LogoImage.CreateFile(_env, "assets", "img", "icon");
            }

            serviceOffer.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.ServiceOffers.AddAsync(serviceOffer);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            ServiceOffer serviceOffer = await _context.ServiceOffers.FirstOrDefaultAsync(s => s.Id == id);

            if (serviceOffer == null) return NotFound();

            ViewBag.ServiceOffer = await _context.ServiceOffers.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            return View(serviceOffer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ServiceOffer serviceOffer, bool? status, int page = 1)
        {
            ViewBag.ServiceOffer = await _context.ServiceOffers.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            ServiceOffer dbServiceOffer = await _context.ServiceOffers.FirstOrDefaultAsync(s => s.Id == id);

            if (dbServiceOffer == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbServiceOffer);
            }

            if (id != dbServiceOffer.Id) return BadRequest();

            serviceOffer.Title = serviceOffer.Title.Trim();
            serviceOffer.Description = serviceOffer.Title.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(serviceOffer.Title) && regex.IsMatch(serviceOffer.Description))
            {
                ModelState.AddModelError("Name", "Should not be Space");
                ModelState.AddModelError("Description", "Should not be Space");
                return View();
            }

            for (int i = 0; i < serviceOffer.BgColor.Length; i++)
            {
                if (serviceOffer.BgColor[i] == ' ')
                {
                    ModelState.AddModelError("BgColor", "Should not be Space");
                    return View();
                }
            }

            if (serviceOffer.LogoImage != null)
            {
                if (!serviceOffer.LogoImage.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("LogoImage", "Image type must be in PNG format!");
                    return View();
                }

                if (!serviceOffer.LogoImage.CheckFileSize(30))
                {
                    ModelState.AddModelError("LogoImage", "Image size must be a maximum of 30KB!");
                    return View();
                }

                Helper.DeleteFile(_env, dbServiceOffer.Image, "assets", "img", "icon");

                dbServiceOffer.Image = serviceOffer.LogoImage.CreateFile(_env, "assets", "img", "icon");
            }

            dbServiceOffer.Title = serviceOffer.Title;
            dbServiceOffer.Description = serviceOffer.Description;
            dbServiceOffer.BgColor = serviceOffer.BgColor;
            dbServiceOffer.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            ServiceOffer dbserviceOffer = await _context.ServiceOffers.FirstOrDefaultAsync(s => s.Id == id);

            if (dbserviceOffer == null) return NotFound();

            dbserviceOffer.IsDeleted = true;
            dbserviceOffer.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();


            IEnumerable<ServiceOffer> serviceOffers = await _context.ServiceOffers
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)serviceOffers.Count() / 5);

            return PartialView("_ServiceOfferIndexPartial", serviceOffers.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            ServiceOffer dbServiceOffer = await _context.ServiceOffers.FirstOrDefaultAsync(s => s.Id == id);

            if (dbServiceOffer == null) return NotFound();

            dbServiceOffer.IsDeleted = false;

            await _context.SaveChangesAsync();

            IEnumerable<ServiceOffer> serviceOffers = await _context.ServiceOffers
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)serviceOffers.Count() / 5);

            return PartialView("_ServiceOfferIndexPartial", serviceOffers.Skip((page - 1) * 5).Take(5));
        }
    }
}
