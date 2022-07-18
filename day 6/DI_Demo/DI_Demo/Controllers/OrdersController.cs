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
    public class OrdersController : Controller
    {
        private readonly shoppingP2APPContext _context;

        public OrdersController(shoppingP2APPContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var shoppingP2APPContext = _context.OrdersLists.Include(o => o.Product).Include(o => o.User);
            return View(await shoppingP2APPContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrdersLists == null)
            {
                return NotFound();
            }

            var ordersList = await _context.OrdersLists
                .Include(o => o.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (ordersList == null)
            {
                return NotFound();
            }

            return View(ordersList);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.ProductLists, "PId", "PId");
            ViewData["UserId"] = new SelectList(_context.Registers, "DesiredUserName", "DesiredUserName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderDate,ProductId,OrderQty,OrderCost,UserId")] OrdersList ordersList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordersList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.ProductLists, "PId", "PId", ordersList.ProductId);
            ViewData["UserId"] = new SelectList(_context.Registers, "DesiredUserName", "DesiredUserName", ordersList.UserId);
            return View(ordersList);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdersLists == null)
            {
                return NotFound();
            }

            var ordersList = await _context.OrdersLists.FindAsync(id);
            if (ordersList == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.ProductLists, "PId", "PId", ordersList.ProductId);
            ViewData["UserId"] = new SelectList(_context.Registers, "DesiredUserName", "DesiredUserName", ordersList.UserId);
            return View(ordersList);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderDate,ProductId,OrderQty,OrderCost,UserId")] OrdersList ordersList)
        {
            if (id != ordersList.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordersList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersListExists(ordersList.OrderId))
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
            ViewData["ProductId"] = new SelectList(_context.ProductLists, "PId", "PId", ordersList.ProductId);
            ViewData["UserId"] = new SelectList(_context.Registers, "DesiredUserName", "DesiredUserName", ordersList.UserId);
            return View(ordersList);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrdersLists == null)
            {
                return NotFound();
            }

            var ordersList = await _context.OrdersLists
                .Include(o => o.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (ordersList == null)
            {
                return NotFound();
            }

            return View(ordersList);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrdersLists == null)
            {
                return Problem("Entity set 'shoppingP2APPContext.OrdersLists'  is null.");
            }
            var ordersList = await _context.OrdersLists.FindAsync(id);
            if (ordersList != null)
            {
                _context.OrdersLists.Remove(ordersList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersListExists(int id)
        {
          return (_context.OrdersLists?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
