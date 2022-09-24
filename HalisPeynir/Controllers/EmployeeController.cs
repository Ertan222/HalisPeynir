using HalisPeynir.Data;
using HalisPeynir.Models;
using HalisPeynir.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HalisPeynir.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HalisPeynirDBContext _context;

        public EmployeeController(HalisPeynirDBContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> List()
        {

            List<Employee> employeeList = await _context.Employees.
                Include(a => a.Gender).
                Include(a => a.JobTitle).
                Include(a => a.Shift).
                OrderByDescending
                (a => a.EmployeeID).ToListAsync()
                ;
            return View(employeeList);
        }

        public async Task<IActionResult> Add()
        {
            EmployeeViewModel x = new EmployeeViewModel();
            x.Employee = new Employee();
            x.JobTitleList = await _context.JobTitles.ToListAsync();
            x.GenderList = await _context.Genders.ToListAsync();
            x.ShiftList = await _context.Shifts.ToListAsync();

            return View(x);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Add([Bind("NameAndSecName ,Surname, DOB, GenderID,JobTitleID,ShiftID,WorkStatus")] Employee employee)
        {
            ModelState.Remove("Gender");
            ModelState.Remove("JobTitle");
            ModelState.Remove("Shift");
            if (ModelState.IsValid)
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("List", "Employee");
            }

            EmployeeViewModel x = new EmployeeViewModel();
            x.Employee = employee;
            x.JobTitleList = await _context.JobTitles.ToListAsync();
            x.GenderList = await _context.Genders.ToListAsync();
            x.ShiftList = await _context.Shifts.ToListAsync();
            return View(x);
        }
        public async Task<IActionResult> Info(int id)
        {
            Employee selectedEmployeeViewModel= await _context.Employees.Include(a => a.Gender).
                Include(a => a.JobTitle).Include(a => a.Shift).
                FirstOrDefaultAsync(a => a.EmployeeID == id);
            
            return View(selectedEmployeeViewModel);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Employee selectedEmployee = await _context.Employees.Include(a => a.Gender).
                Include(a => a.JobTitle).Include(a => a.Shift).FirstOrDefaultAsync(a => a.EmployeeID == id);

            return View(selectedEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RealDelete(int id)
        {
            Employee selectedEmployee = await _context.Employees.FirstOrDefaultAsync(a => a.EmployeeID == id);
            _context.Employees.Remove(selectedEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction("List", "Employee");

        }
        public async Task<IActionResult> Edit(int id)
        {

            EmployeeViewModel selectedEmployeeViewModel = new();
            selectedEmployeeViewModel.Employee = await _context.Employees.FirstOrDefaultAsync(a => a.EmployeeID== id);
            selectedEmployeeViewModel.JobTitleList = await _context.JobTitles.ToListAsync();
            selectedEmployeeViewModel.GenderList = await _context.Genders.ToListAsync();
            selectedEmployeeViewModel.ShiftList= await _context.Shifts.ToListAsync();
            

            return View(selectedEmployeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NameAndSecName ,Surname, DOB, GenderID, JobTitleID, ShiftID, WorkStatus")] Employee employee )
        {
            employee.EmployeeID= id;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("List", "Employee");
        }




    }
}
