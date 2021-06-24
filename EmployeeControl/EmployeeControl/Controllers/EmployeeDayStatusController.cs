using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeControl.Data;
using EmployeeControl.Models;
using EmployeeControl.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace EmployeeControl.Controllers
{
    public class EmployeeDayStatusController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly EmployeeControlContext _context;

        public EmployeeDayStatusController(EmployeeControlContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: EmployeeDayStatus
        public async Task<IActionResult> Index()
        {



            return View(await _context.employeeDayStatuses.Include(x=>x.Idusera).ToListAsync());
        }

        // GET: EmployeeDayStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDayStatus = await _context.employeeDayStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDayStatus == null)
            {
                return NotFound();
            }

            return View(employeeDayStatus);
        }

        // GET: EmployeeDayStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeDayStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeDayStatusUsersListViewModel employeeDayStatusUsersList)
        {
            EmployeeDayStatus employeeDayStatus = employeeDayStatusUsersList;
            var user = await _userManager.GetUserAsync(User);


            employeeDayStatus.Idusera = user;
            employeeDayStatus.statusStartWork = true;
            employeeDayStatus.statusEndWork = false;
            employeeDayStatus.Status = "Working";
           
            if (ModelState.IsValid)
            {
                _context.Add(employeeDayStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDayStatus);
        }

        // GET: EmployeeDayStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDayStatus = await _context.employeeDayStatuses.FindAsync(id);
            if (employeeDayStatus == null)
            {
                return NotFound();
            }
            return View(employeeDayStatus);
        }

        // POST: EmployeeDayStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CheckIn,CheckOut,Notes,Status,statusStartWork,statusEndWork")] EmployeeDayStatus employeeDayStatus)
        {
            if (id != employeeDayStatus.Id)
            {
                return NotFound();
            }

            employeeDayStatus.statusStartWork = true;
            employeeDayStatus.statusEndWork = false;
            employeeDayStatus.Status = "End of work";

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDayStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDayStatusExists(employeeDayStatus.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDayStatus);
        }

        // GET: EmployeeDayStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDayStatus = await _context.employeeDayStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDayStatus == null)
            {
                return NotFound();
            }

            return View(employeeDayStatus);
        }

        // POST: EmployeeDayStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDayStatus = await _context.employeeDayStatuses.FindAsync(id);
            _context.employeeDayStatuses.Remove(employeeDayStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDayStatusExists(int id)
        {
            return _context.employeeDayStatuses.Any(e => e.Id == id);
        }
    }
}
