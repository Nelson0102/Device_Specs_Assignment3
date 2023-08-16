using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Device_Specs_Assignment3.Data;
using Device_Specs_Assignment3.Models;

namespace Device_Specs_Assignment3
{
    public class DevicesController : Controller
    {
        private readonly Device_Specs_Assignment3Context _context;

        public DevicesController(Device_Specs_Assignment3Context context)
        {
            _context = context;
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
              return _context.Devices != null ? 
                          View(await _context.Devices.ToListAsync()) :
                          Problem("Entity set 'Device_Specs_Assignment3Context.Devices'  is null.");
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Devices == null)
            {
                return NotFound();
            }

            var devices = await _context.Devices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (devices == null)
            {
                return NotFound();
            }

            return View(devices);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Company,Device,Storage,Camera,Battery")] Devices devices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(devices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(devices);
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Devices == null)
            {
                return NotFound();
            }

            var devices = await _context.Devices.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }
            return View(devices);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Company,Device,Storage,Camera,Battery")] Devices devices)
        {
            if (id != devices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevicesExists(devices.Id))
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
            return View(devices);
        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Devices == null)
            {
                return NotFound();
            }

            var devices = await _context.Devices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (devices == null)
            {
                return NotFound();
            }

            return View(devices);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Devices == null)
            {
                return Problem("Entity set 'Device_Specs_Assignment3Context.Devices'  is null.");
            }
            var devices = await _context.Devices.FindAsync(id);
            if (devices != null)
            {
                _context.Devices.Remove(devices);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevicesExists(int id)
        {
          return (_context.Devices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
