﻿using Juan_Back_End_Final.DAL;
using Juan_Back_End_Final.Extensions;
using Juan_Back_End_Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juan_Back_End_Final.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class SizeController : Controller
    {
        private readonly JuanDbContext _context;


        public SizeController(JuanDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<Size> sizes = await _context.Sizes
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)sizes.Count() / 5);

            return View(sizes.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Size = await _context.Sizes.Where(s => !s.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Size size, bool? status, int page = 1)
        {
            ViewBag.Size = await _context.Sizes.Where(s => !s.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            for (int i = 0; i < size.Name.Length; i++)
            {
                if (size.Name[i] == ' ')
                {
                    ModelState.AddModelError("Name", "Should not be Space");
                    return View();
                }
            }

            if (await _context.Sizes.AnyAsync(s => s.Name.ToLower() == size.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            size.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Sizes.AddAsync(size);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Size size = await _context.Sizes.FirstOrDefaultAsync(s => s.Id == id);

            if (size == null) return NotFound();

            ViewBag.Size = await _context.Sizes.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            return View(size);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Size size, bool? status, int page = 1)
        {
            ViewBag.Size = await _context.Sizes.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            Size dbSize = await _context.Sizes.FirstOrDefaultAsync(s => s.Id == id);

            if (dbSize == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbSize);
            }

            if (id != size.Id) return BadRequest();

            size.Name = size.Name.Trim();

            for (int i = 0; i < size.Name.Length; i++)
            {
                if (size.Name[i] == ' ')
                {
                    ModelState.AddModelError("Name", "Should not be Space");
                    return View();
                }
            }

            if (await _context.Sizes.AnyAsync(s => s.Id != id && s.Name.ToLower() == size.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View(dbSize);
            }

            dbSize.Name = size.Name;
            dbSize.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }
        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Size dbSize = await _context.Sizes.FirstOrDefaultAsync(s => s.Id == id);

            if (dbSize == null) return NotFound();

            dbSize.IsDeleted = true;
            dbSize.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();


            IEnumerable<Size> sizes = await _context.Sizes
                .Where(c => status != null ? c.IsDeleted == status : true)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)sizes.Count() / 5);

            return PartialView("_SizeIndexPartial", sizes.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Size dbSize = await _context.Sizes.FirstOrDefaultAsync(s => s.Id == id);

            if (dbSize == null) return NotFound();

            dbSize.IsDeleted = false;

            await _context.SaveChangesAsync();

            IEnumerable<Size> sizes = await _context.Sizes
                .Where(c => status != null ? c.IsDeleted == status : true)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)sizes.Count() / 5);

            return PartialView("_SizeIndexPartial", sizes.Skip((page - 1) * 5).Take(5));
        }
    }
}
