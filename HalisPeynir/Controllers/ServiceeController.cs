using HalisPeynir.Data;
using HalisPeynir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HalisPeynir.Controllers
{
    public class ServiceeController : Controller
    {
        private readonly HalisPeynirDBContext _context;

        public ServiceeController(HalisPeynirDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List()
        {
            List<Servicee> serviceList = await _context.Servicees.OrderByDescending(a => a.ServiceeID).ToListAsync();
            return View(serviceList);
        }
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Add([Bind("Name,Price")] Servicee service)
        {
            if (ModelState.IsValid)
            {
                await _context.Servicees.AddAsync(service);
                await _context.SaveChangesAsync();
                return RedirectToAction("List", "Servicee");
            }
            return View();
        }
        public async Task<IActionResult> Info(int id)
        {

            Servicee selectedService = await _context.Servicees.FirstOrDefaultAsync(a => a.ServiceeID== id);

            return View(selectedService);
        }

        public async Task<IActionResult> Delete(int id)
        {

            Servicee selectedService= await _context.Servicees.FirstOrDefaultAsync(a => a.ServiceeID== id);

            return View(selectedService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RealDelete(int id)
        {
            Servicee selectedService = await _context.Servicees.FirstOrDefaultAsync(a => a.ServiceeID== id);
            _context.Servicees.Remove(selectedService);
            await _context.SaveChangesAsync();
            return RedirectToAction("List", "Servicee");

        }
        public async Task<IActionResult> Edit(int id)
        {

            Servicee selectedService = await _context.Servicees.FirstOrDefaultAsync(a => a.ServiceeID== id);
            return View(selectedService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Price")] Servicee insertedService)
        {
            insertedService.ServiceeID= id;
            _context.Servicees.Update(insertedService);
            await _context.SaveChangesAsync();
            return RedirectToAction("List", "Servicee");
        }


    }
}
