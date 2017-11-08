using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sos2.Data;
using Sos2.Models;

namespace Sos2.Controllers
{
    public class BasicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BasicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Basics
        public async Task<IActionResult> Index()
        {
            return View(await _context.BasicTable.ToListAsync());
        }

        // GET: Basics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basic = await _context.BasicTable
                .SingleOrDefaultAsync(m => m.ID == id);
            if (basic == null)
            {
                return NotFound();
            }

            return View(basic);
        }

        // GET: Basics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Basics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,What,When,Where")] Basic basic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(basic);
        }

        // GET: Basics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basic = await _context.BasicTable.SingleOrDefaultAsync(m => m.ID == id);
            if (basic == null)
            {
                return NotFound();
            }
            return View(basic);
        }

        // POST: Basics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,What,When,Where")] Basic basic)
        {
            if (id != basic.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasicExists(basic.ID))
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
            return View(basic);
        }

        // GET: Basics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basic = await _context.BasicTable
                .SingleOrDefaultAsync(m => m.ID == id);
            if (basic == null)
            {
                return NotFound();
            }

            return View(basic);
        }

        // POST: Basics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basic = await _context.BasicTable.SingleOrDefaultAsync(m => m.ID == id);
            _context.BasicTable.Remove(basic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasicExists(int id)
        {
            return _context.BasicTable.Any(e => e.ID == id);
        }
    }
}
