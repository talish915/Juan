using Juan_Back_End_Final.DAL;
using Juan_Back_End_Final.Extensions;
using Juan_Back_End_Final.Helpers;
using Juan_Back_End_Final.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class BrandController : Controller
    {
        private readonly JuanDbContext _context;
        private readonly IWebHostEnvironment _env;


        public BrandController(JuanDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<Brand> brands = await _context.Brands
                .Where(b => status != null ? b.IsDeleted == status : true)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)brands.Count() / 5);

            return View(brands.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Brands = await _context.Brands.Where(c => !c.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand, bool? status, int page = 1)
        {
            ViewBag.Brands = await _context.Brands.Where(b => !b.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            brand.Name = brand.Name.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(brand.Name))
            {
                ModelState.AddModelError("Name", "Should not be Space");
                return View();
            }

            for (int i = 0; i < brand.Link.Length; i++)
            {
                if (brand.Link[i]==' ')
                {
                    ModelState.AddModelError("Link", "Should not be Space");
                    return View();
                }
            }

            if (await _context.Brands.AnyAsync(b => b.Name.ToLower() == brand.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }
            if (brand.LogoImage == null)
            {
                ModelState.AddModelError("LogoImage", "Image Must be chosen!");
                return View();
            }
            else
            {
                if (!brand.LogoImage.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("LogoImage", "Image type must be in PNG format!");
                    return View();
                }

                if (!brand.LogoImage.CheckFileSize(30))
                {
                    ModelState.AddModelError("LogoImage", "Image size must be a maximum of 30KB!");
                    return View();
                }
                brand.Image = brand.LogoImage.CreateFile(_env, "assets", "img", "brand");
            }

            brand.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Brand brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);

            if (brand == null) return NotFound();

            ViewBag.Brand = await _context.Brands.Where(c => c.Id != id && !c.IsDeleted).ToListAsync();

            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Brand brand, bool? status, int page = 1)
        {
            ViewBag.Brand = await _context.Brands.Where(b => b.Id != id && !b.IsDeleted).ToListAsync();

            Brand dbBrand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);

            if (dbBrand == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbBrand);
            }

            if (id != brand.Id) return BadRequest();

            brand.Name = brand.Name.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(brand.Name))
            {
                ModelState.AddModelError("Name", "Should not be Space");
                return View();
            }

            for (int i = 0; i < brand.Link.Length; i++)
            {
                if (brand.Link[i] == ' ')
                {
                    ModelState.AddModelError("Link", "Should not be Space");
                    return View(dbBrand);
                }
            }

            if (await _context.Brands.AnyAsync(b => b.Id != id && b.Name.ToLower() == brand.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View(dbBrand);
            }

            if (brand.LogoImage != null)
            {
                if (!brand.LogoImage.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("LogoImage", "Image type must be in PNG format!");
                    return View();
                }

                if (!brand.LogoImage.CheckFileSize(30))
                {
                    ModelState.AddModelError("LogoImage", "Image size must be a maximum of 30KB!");
                    return View();
                }

                Helper.DeleteFile(_env, dbBrand.Image, "assets", "img", "brand");

                dbBrand.Image = brand.LogoImage.CreateFile(_env, "assets", "img", "brand");
            }

            dbBrand.Name = brand.Name;
            dbBrand.Link = brand.Link;
            dbBrand.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Brand dbBrand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);

            if (dbBrand == null) return NotFound();

            dbBrand.IsDeleted = true;
            dbBrand.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();


            IEnumerable<Brand> brands = await _context.Brands
                .Where(b => status != null ? b.IsDeleted == status : true)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)brands.Count() / 5);

            return PartialView("_BrandIndexPartial", brands.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Brand dbBrand = await _context.Brands.FirstOrDefaultAsync(s => s.Id == id);

            if (dbBrand == null) return NotFound();

            dbBrand.IsDeleted = false;

            await _context.SaveChangesAsync();

            IEnumerable<Brand> brands = await _context.Brands
                .Where(b => status != null ? b.IsDeleted == status : true)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)brands.Count() / 5);

            return PartialView("_BrandIndexPartial", brands.Skip((page - 1) * 5).Take(5));
        }
    }
}
