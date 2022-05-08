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
    public class ShopController : Controller
    {

        private readonly JuanDbContext _context;
        public ShopController(JuanDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string sortby)
        {
            List<Product> products = new List<Product>();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            switch (sortby)
            {
                case "AZ":
                    products = await _context.Products.OrderBy(p => p.Title).ToListAsync();
                    break;
                case "ZA":
                    products = await _context.Products.OrderByDescending(p => p.Title).ToListAsync();
                    break;
                default:
                    products = await _context.Products
                        .Include(p => p.ProductColorSizes).ThenInclude(p => p.Color)
                        .Include(p => p.ProductColorSizes).ThenInclude(p => p.Size)
                        .OrderBy(p => p.Title).ToListAsync();
                    break;
            }
            return View(products);
        }
    }
}
