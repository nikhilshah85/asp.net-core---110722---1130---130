using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DI_Demo.Models.EF;

namespace DI_Demo.Controllers
{
    public class RegistersController : Controller
    {
        private readonly shoppingP2APPContext _context;

        public RegistersController(shoppingP2APPContext context)
        {
            _context = context;
        }

        // GET: Registers
        public async Task<IActionResult> Index()
        {
              return _context.Registers != null ? 
                          View(await _context.Registers.ToListAsync()) :
                          Problem("Entity set 'shoppingP2APPContext.Registers'  is null.");
        }

        // GET: Registers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .FirstOrDefaultAsync(m => m.DesiredUserName == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: Registers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DesiredUserName,DesiredPassword,FirstName,LastName,EmailAddress,ContactNo,Age,City,Address")] Register register)
        {
            if (ModelState.IsValid)
            {
                _context.Add(register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }

        // GET: Registers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            return View(register);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DesiredUserName,DesiredPassword,FirstName,LastName,EmailAddress,ContactNo,Age,City,Address")] Register register)
        {
            if (id != register.DesiredUserName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.DesiredUserName))
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
            return View(register);
        }

        // GET: Registers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .FirstOrDefaultAsync(m => m.DesiredUserName == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Registers == null)
            {
                return Problem("Entity set 'shoppingP2APPContext.Registers'  is null.");
            }
            var register = await _context.Registers.FindAsync(id);
            if (register != null)
            {
                _context.Registers.Remove(register);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterExists(string id)
        {
          return (_context.Registers?.Any(e => e.DesiredUserName == id)).GetValueOrDefault();
        }
    }
}
