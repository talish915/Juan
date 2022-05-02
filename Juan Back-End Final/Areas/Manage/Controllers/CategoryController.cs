﻿using Juan_Back_End_Final.DAL;
using Juan_Back_End_Final.Extensions;
using Juan_Back_End_Final.Models;
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
    public class CategoryController : Controller
    {
        private readonly JuanDbContext _context;
        private readonly IWebHostEnvironment _env;


        public CategoryController(JuanDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<Category> categories = await _context.Categories
                .Include(t => t.Products)
                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)categories.Count() / 5);

            return View(categories.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Create(bool? status,int page = 1)
        {
            ViewBag.MainCategory = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category, bool? status, int page = 1)
        {
            ViewBag.MainCategory = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                ModelState.AddModelError("Name", "Should not be Space");
                return View();
            }

            if (category.Name.CheckString())
            {
                ModelState.AddModelError("Name", "Should only be Letters");
                return View();
            }

            if (await _context.Categories.AnyAsync(t => t.Name.ToLower() == category.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            category.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Update(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return NotFound();

            ViewBag.MainCategory = await _context.Categories.Where(c => c.Id != id && !c.IsDeleted).ToListAsync();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Category category, bool? status, int page = 1)
        {
            ViewBag.MainCategory = await _context.Categories.Where(c => c.Id != id && !c.IsDeleted).ToListAsync();

            Category dbCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (dbCategory == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbCategory);
            }

            if (id != category.Id) return BadRequest();

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                ModelState.AddModelError("Name", "Bosluq Olmamalidir");
                return View(dbCategory);
            }

            if (category.Name.CheckString())
            {
                ModelState.AddModelError("Name", "Yalniz Herf Ola Biler");
                return View(dbCategory);
            }

            if (await _context.Categories.AnyAsync(t => t.Id != id && t.Name.ToLower() == category.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View(dbCategory);
            }

            dbCategory.Name = category.Name;
            dbCategory.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }
        public async Task<IActionResult> Delete(int? id, int page = 1)
        {
            if (id == null) return BadRequest();

            Category dbCategory = await _context.Categories.FirstOrDefaultAsync(t => t.Id == id);

            if (dbCategory == null) return NotFound();

            dbCategory.IsDeleted = true;
            dbCategory.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Restore(int? id, int page = 1)
        {
            if (id == null) return BadRequest();

            Category dbCategory = await _context.Categories.FirstOrDefaultAsync(t => t.Id == id);

            if (dbCategory == null) return NotFound();

            dbCategory.IsDeleted = false;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
