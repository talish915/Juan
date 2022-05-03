using Juan_Back_End_Final.DAL;
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
    public class SocialController : Controller
    {
        private readonly JuanDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SocialController(JuanDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<Social> socials = await _context.Socials
                .Where(s => status != null ? s.IsDeleted == status : true)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)socials.Count() / 5);

            return View(socials.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Social = await _context.Socials.Where(s => !s.IsDeleted).ToListAsync();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Social social, bool? status, int page = 1)
        {
            ViewBag.Social = await _context.Socials.Where(s => !s.IsDeleted).ToListAsync();

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (string.IsNullOrWhiteSpace(social.Name))
            {
                ModelState.AddModelError("Name", "Should not be Space");
                return View();
            }

            if (await _context.Sizes.AnyAsync(s => s.Name.ToLower() == social.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View();
            }

            social.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Socials.AddAsync(social);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();

            Social social = await _context.Socials.FirstOrDefaultAsync(s => s.Id == id);

            if (social == null) return NotFound();

            ViewBag.Social = await _context.Socials.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            return View(social);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Social social, bool? status, int page = 1)
        {
            ViewBag.Social = await _context.Socials.Where(s => s.Id != id && !s.IsDeleted).ToListAsync();

            Social dbSocial = await _context.Socials.FirstOrDefaultAsync(s => s.Id == id);

            if (dbSocial == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dbSocial);
            }

            if (id != social.Id) return BadRequest();

            if (string.IsNullOrWhiteSpace(social.Name))
            {
                ModelState.AddModelError("Name", "Should not be Space");
                return View(dbSocial);
            }

            if (social.Name.CheckString())
            {
                ModelState.AddModelError("Name", "Should only be Letters");
                return View(dbSocial);
            }

            if (await _context.Socials.AnyAsync(s => s.Id != id && s.Name.ToLower() == social.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "Alreade Exists");
                return View(dbSocial);
            }

            dbSocial.Name = social.Name;
            dbSocial.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            Social dbSocial = await _context.Socials.FirstOrDefaultAsync(s => s.Id == id);

            if (dbSocial == null) return NotFound();

            dbSocial.IsDeleted = true;
            dbSocial.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Restore(int? id)
        {
            if (id == null) return BadRequest();

            Social dbSocial = await _context.Socials.FirstOrDefaultAsync(s => s.Id == id);

            if (dbSocial == null) return NotFound();

            dbSocial.IsDeleted = false;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
