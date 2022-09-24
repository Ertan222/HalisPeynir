using HalisPeynir.Data;
using HalisPeynir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HalisPeynir.Controllers
{
    public class GenderController : Controller
    {
        private readonly HalisPeynirDBContext _context;

        public GenderController(HalisPeynirDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> List()
        {
            List<Gender> genderList = await _context.Genders.OrderByDescending(a => a.GenderID).ToListAsync();
            return View(genderList);
        }


        public async Task<IActionResult> Add()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("GenderName")] Gender gender)
        {

            if (ModelState.IsValid)
            {
                await _context.Genders.AddAsync(gender);
                await _context.SaveChangesAsync();
                return RedirectToAction("List", "Gender");
            }

            return View();

        }

        public async Task<IActionResult> Info(int id)
        {

            Gender selectedGender = await _context.Genders.FirstOrDefaultAsync(a => a.GenderID == id);

            return View(selectedGender);
        }



        public async Task<IActionResult> Delete(int id)
        {

            Gender selectedGender = await _context.Genders.FirstOrDefaultAsync(a => a.GenderID == id);

            return View(selectedGender);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RealDelete(int id)
        {
            Gender selectedGender = await _context.Genders.FirstOrDefaultAsync(a => a.GenderID == id);
            _context.Genders.Remove(selectedGender);
            await _context.SaveChangesAsync();
            return RedirectToAction("List", "Gender");

        }


        public async Task<IActionResult> Edit(int id)
        {

            Gender selectedGender = await _context.Genders.FirstOrDefaultAsync(a => a.GenderID == id);
            return View(selectedGender);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenderID,GenderName")] Gender insertedGender)
        {
            insertedGender.GenderID = id;
            _context.Genders.Update(insertedGender);
            await _context.SaveChangesAsync();
            return RedirectToAction("List", "Gender");
        }
    }
}
