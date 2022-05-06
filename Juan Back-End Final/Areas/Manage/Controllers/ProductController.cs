using Juan_Back_End_Final.DAL;
using Juan_Back_End_Final.Extensions;
using Juan_Back_End_Final.Helpers;
using Juan_Back_End_Final.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class ProductController : Controller
    {
        private readonly JuanDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(JuanDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<Product> products = await _context.Products
                .Include(p => p.Category)
                .Where(p => status != null ? p.IsDeleted == status : !p.IsDeleted)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)products.Count() / 5);

            return View(products.Skip((page - 1) * 5).Take(5));
        }

        public async Task<IActionResult> Create(bool? status, int page = 1)
        {
            ViewBag.Categories = await _context.Categories.Where(p => !p.IsDeleted).ToListAsync();
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, bool? status, int page = 1)
        {
            ViewBag.Categories = await _context.Categories.Where(b => !b.IsDeleted).ToListAsync();
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }
            product.Title = product.Title.Trim();
            product.Description = product.Description.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(product.Title) && regex.IsMatch(product.Description))
            {
                ModelState.AddModelError("Title", "Should not be Space");
                ModelState.AddModelError("Description", "Should not be Space");
                return View();
            }
            if (product.ProductImagesFile.Count() > 6)
            {
                ModelState.AddModelError("ProductImagesFile", $"maksimum yukleyebileceyin say 6");
                return View();
            }

            if (product.SizeIds.Count != product.ColorIds.Count || product.SizeIds.Count != product.Counts.Count || product.Counts.Count != product.ColorIds.Count)
            {
                ModelState.AddModelError("", "Incorect");
                return View();
            }

            foreach (int item in product.SizeIds)
            {
                if (!await _context.Sizes.AnyAsync(s => s.Id == item))
                {
                    ModelState.AddModelError("", "Incorect Size Id");
                    return View();
                }
            }

            foreach (int item in product.ColorIds)
            {
                if (!await _context.Colors.AnyAsync(s => s.Id == item))
                {
                    ModelState.AddModelError("", "Incorect Color Id");
                    return View();
                }
            }

            List<ProductColorSize> productColorSizes = new List<ProductColorSize>();

            for (int i = 0; i < product.ColorIds.Count; i++)
            {
                ProductColorSize productColorSize = new ProductColorSize
                {
                    ColorId = product.ColorIds[i],
                    SizeId = product.SizeIds[i],
                    Count = product.Counts[i]
                };

                productColorSizes.Add(productColorSize);
            }

            product.ProductColorSizes = productColorSizes;

            if (!await _context.Categories.AnyAsync(b => b.Id == product.CategoryId && !b.IsDeleted))
            {
                ModelState.AddModelError("CategoryId", "Choose the correct category");
                return View();
            }

            if (product.MainImageFile != null)
            {
                if (!product.MainImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("MainImageFile", "The image must be of jpeg and jpg type!");
                    return View();
                }

                if (!product.MainImageFile.CheckFileSize(300))
                {
                    ModelState.AddModelError("MainImageFile", "The selected image must be 300 Kb in size!");
                    return View();
                }

                product.Image = product.MainImageFile.CreateFile(_env, "assets", "img", "product");
            }
            else
            {
                ModelState.AddModelError("MainImageFile", "The image must be selected");
                return View();
            }

            if (product.ProductImagesFile.Count() > 0)
            {
                List<ProductImage> productImages = new List<ProductImage>();

                foreach (IFormFile file in product.ProductImagesFile)
                {
                    if (!file.CheckFileContentType("image/jpeg"))
                    {
                        ModelState.AddModelError("ProductImagesFile", "The image must be of jpeg and jpg type!");
                        return View();
                    }

                    if (!file.CheckFileSize(300))
                    {
                        ModelState.AddModelError("ProductImagesFile", "The selected image must be 300 Kb in size!");
                        return View();
                    }

                    ProductImage productImage = new ProductImage
                    {
                        Image = file.CreateFile(_env, "assets", "img", "product"),
                        CreatedAt = DateTime.UtcNow.AddHours(4)
                    };

                    productImages.Add(productImage);
                }

                product.ProductImages = productImages;
            }
            else
            {
                ModelState.AddModelError("ProductImagesFile", "The image must be selected");
                return View();
            }

            product.Availability = product.Count > 0 ? true : false;
            product.CreatedAt = DateTime.UtcNow.AddHours(4);
            product.Count = product.Counts.Sum();

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }

        public async Task<IActionResult> Update(int? id, bool? status, int page = 1)
        {
            ViewBag.Categories = await _context.Categories.Where(b => !b.IsDeleted).ToListAsync();
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();

            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Product product, bool? status, int page = 1)
        {
            ViewBag.Categories = await _context.Categories.Where(b => !b.IsDeleted).ToListAsync();
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();

            if (id == null) return BadRequest();

            if (id != product.Id) return BadRequest();

            Product dbProduct = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (dbProduct == null) return NotFound();

            if (!ModelState.IsValid) return View(dbProduct);

            product.Title = product.Title.Trim();
            product.Description = product.Description.Trim();

            Regex regex = new Regex(@"\s{2,}");
            if (regex.IsMatch(product.Title) && regex.IsMatch(product.Description))
            {
                ModelState.AddModelError("Title", "Should not be Space");
                ModelState.AddModelError("Description", "Should not be Space");
                return View();
            }

            int canuploadimage = 6 - (int)(dbProduct.ProductImages?.Where(p => !p.IsDeleted).Count());

            if (product.ProductImagesFile != null && product.ProductImagesFile.Length > canuploadimage)
            {
                ModelState.AddModelError("ProductImagesFile", $"Maximum number of pictures you can choose {canuploadimage}");
                return View(dbProduct);
            }

            if (!await _context.Categories.AnyAsync(b => b.Id == product.CategoryId && !b.IsDeleted))
            {
                ModelState.AddModelError("CategoryId", "Choose the correct category");
                return View(product);
            }

            if (product.MainImageFile != null)
            {
                if (!product.MainImageFile.CheckFileContentType("image/jpeg"))
                {
                    ModelState.AddModelError("MainImageFile", "The image must be of jpeg and jpg type!");
                    return View();
                }

                if (!product.MainImageFile.CheckFileSize(300))
                {
                    ModelState.AddModelError("MainImageFile", "The selected image must be 300 Kb in size!");
                    return View();
                }
                Helper.DeleteFile(_env, dbProduct.Image, "assets", "img", "product");

                dbProduct.Image = product.MainImageFile.CreateFile(_env, "assets", "img", "product");
            }

            if (product.ProductImagesFile != null && product.ProductImagesFile.Count() > 0)
            {
                List<ProductImage> productImages = new List<ProductImage>();

                foreach (IFormFile file in product.ProductImagesFile)
                {
                    if (!file.CheckFileContentType("image/jpeg"))
                    {
                        ModelState.AddModelError("ProductImagesFile", "The image must be of jpeg and jpg type!");
                        return View();
                    }

                    if (!file.CheckFileSize(300))
                    {
                        ModelState.AddModelError("ProductImagesFile", "The selected image must be 300 Kb in size!");
                        return View();
                    }

                    ProductImage productImage = new ProductImage
                    {
                        Image = file.CreateFile(_env, "assets", "img", "product"),
                        CreatedAt = DateTime.UtcNow.AddHours(4)
                    };

                    dbProduct.ProductImages.Add(productImage);
                }
            }

            dbProduct.CategoryId = product.CategoryId;
            dbProduct.Title = product.Title;
            dbProduct.Price = product.Price;
            dbProduct.DiscountPrice = product.DiscountPrice;
            dbProduct.Description = product.Description;
            dbProduct.Count = product.Count;
            dbProduct.Availability = product.Count > 0 ? true : false;
            dbProduct.ProductColorSizes = product.ProductColorSizes;
            dbProduct.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }

        public async Task<IActionResult> DeleteImage(int? id)
        {
            ViewBag.Categories = await _context.Categories.Where(b => !b.IsDeleted).ToListAsync();

            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.ProductImages.Any(pi => pi.Id == id && !pi.IsDeleted));

            if (product == null) return NotFound();

            product.ProductImages.FirstOrDefault(p => p.Id == id).IsDeleted = true;
            product.ProductImages.FirstOrDefault(p => p.Id == id).DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_ProductUpdateImagePartial", product);
        }

        public async Task<IActionResult> Delete(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            return View(product);
        }
        public async Task<IActionResult> DeleteProduct(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return NotFound();

            product.IsDeleted = true;
            product.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status, page });
        }

        public async Task<IActionResult> GetFormColoRSizeCount()
        {
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Sizes = await _context.Sizes.ToListAsync();

            return PartialView("_ProductColorSizePartial");
        }
    }
}
