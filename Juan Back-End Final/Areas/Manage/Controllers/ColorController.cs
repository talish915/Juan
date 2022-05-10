using Juan_Back_End_Final.DAL;
using Juan_Back_End_Final.Extensions;
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
    public class ColorController : Controller
    {
        private readonly JuanDbContext _context;


        public ColorController(JuanDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<Color> colors = await _context.Colors
                .Where(c => status != null ? c.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)colors.Count() / 5);

            return View(colors.Skip((page - 1) * 5).Take(5));
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Color = await _context.Colors.Where(c => !c.IsDeleted).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Color color, bool? status, int page = 1)
        {
            ViewBag.Colors = await _context.Colors.Where(c => !c.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            color.Name = color.Name.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(color.Name))
            {
                ModelState.AddModelError("Name", "Should not be Space");
                return View();
            }

            if (await _context.Colors.AnyAsync(c => c.Name.ToLower() == color.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            color.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Colors.AddAsync(color);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Color color = await _context.Colors.FirstOrDefaultAsync(c => c.Id == id);

            if (color == null) return NotFound();

            ViewBag.Colors = await _context.Colors.Where(c => c.Id != id && !c.IsDeleted).ToListAsync();

            return View(color);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Color color, bool? status, int page = 1)
        {
            ViewBag.Colors = await _context.Colors.Where(c => c.Id != id && !c.IsDeleted).ToListAsync();

            Color dbColor = await _context.Colors.FirstOrDefaultAsync(c => c.Id == id);

            if (dbColor == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbColor);
            }

            if (id != color.Id) return BadRequest();

            color.Name = color.Name.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(color.Name))
            {
                ModelState.AddModelError("Name", "Should not be Space");
                return View();
            }

            if (await _context.Colors.AnyAsync(c => c.Id != id && c.Name.ToLower() == color.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View(dbColor);
            }

            dbColor.Name = color.Name;
            dbColor.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }
        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Color dbColor = await _context.Colors.FirstOrDefaultAsync(c => c.Id == id);

            if (dbColor == null) return NotFound();

            dbColor.IsDeleted = true;
            dbColor.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            IEnumerable<Color> color = await _context.Colors
                .Where(c => status != null ? c.IsDeleted == status : true)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)color.Count() / 5);

            return PartialView("_ColorIndexPartial", color.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Restore(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Color dbColor = await _context.Colors.FirstOrDefaultAsync(c => c.Id == id);

            if (dbColor == null) return NotFound();

            dbColor.IsDeleted = false;

            await _context.SaveChangesAsync();

            IEnumerable<Color> colors = await _context.Colors
                .Where(c => status != null ? c.IsDeleted == status : true)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)colors.Count() / 5);

            return PartialView("_ColorIndexPartial", colors.Skip((page - 1) * 5).Take(5));
        }
    }
}
