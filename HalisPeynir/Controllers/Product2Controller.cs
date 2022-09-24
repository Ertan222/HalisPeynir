 using HalisPeynir.Data;
using HalisPeynir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HalisPeynir.Controllers
{
    public class Product2Controller : Controller
    {
        private readonly HalisPeynirDBContext _context;

        public Product2Controller(HalisPeynirDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List()
        {
            List<Product> productList = await _context.Products.OrderByDescending(a => a.ProductID).ToListAsync();
            return View(productList);
        }

        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Add([Bind("Name,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("List", "Product2");
            }
            return View();
        }

        public async Task<IActionResult>Info(int id)
        {

            Product selectedProduct = await _context.Products.FirstOrDefaultAsync(a => a.ProductID == id);

            return View(selectedProduct);
        }

        public async Task<IActionResult> Delete(int id)
        {

            Product selectedProduct = await _context.Products.FirstOrDefaultAsync(a => a.ProductID == id);

            return View(selectedProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RealDelete(int id)
        {
            Product selectedProduct = await _context.Products.FirstOrDefaultAsync(a => a.ProductID == id);
            _context.Products.Remove(selectedProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction("List", "Product2");

        }
        public async Task<IActionResult> Edit(int id)
        {

            Product selectedProduct = await _context.Products.FirstOrDefaultAsync(a => a.ProductID == id);
            return View(selectedProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Price")] Product insertedProduct)
        {
            insertedProduct.ProductID = id;
            _context.Products.Update(insertedProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction("List", "Product2");
        }
    }
}
