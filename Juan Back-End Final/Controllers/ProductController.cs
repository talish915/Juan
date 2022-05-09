using Juan_Back_End_Final.DAL;
using Juan_Back_End_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Juan_Back_End_Final.Controllers
{
    public class ProductController : Controller
    {
        private readonly JuanDbContext _context;

        public ProductController(JuanDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.Products = await _context.Products.Where(p => !p.IsDeleted).ToListAsync();
            ViewBag.Colors = await _context.Colors.Where(p => !p.IsDeleted).ToListAsync();
            ViewBag.Sizes = await _context.Sizes.Where(p => !p.IsDeleted).ToListAsync();

            Product product = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                .Include(p => p.ProductColorSizes).ThenInclude(p => p.Size)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            return View(product);
        }
    }
}
