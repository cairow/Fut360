using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fut360.Data;
using Fut360.Models;

namespace Fut360.Controllers
{
    public class LocalController : Controller
    {
        private readonly Contexto _context;

        public LocalController(Contexto context)
        {
            _context = context;
        }

        // GET: Local
        public async Task<IActionResult> Index()
        {
              return _context.Local != null ? 
                          View(await _context.Local.ToListAsync()) :
                          Problem("Entity set 'Contexto.local'  is null.");
        }

        // GET: Local/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Local == null)
            {
                return NotFound();
            }

            var localModel = await _context.Local
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localModel == null)
            {
                return NotFound();
            }

            return View(localModel);
        }

        // GET: Local/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Local/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Endereco,Horario,Pagamento")] LocalModel localModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localModel);
        }

        // GET: Local/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Local == null)
            {
                return NotFound();
            }

            var localModel = await _context.Local.FindAsync(id);
            if (localModel == null)
            {
                return NotFound();
            }
            return View(localModel);
        }

        // POST: Local/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Endereco,Horario,Pagamento")] LocalModel localModel)
        {
            if (id != localModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (LocalModelExists(localModel.Id))
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
            return View(localModel);
        }

        // GET: Local/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Local == null)
            {
                return NotFound();
            }

            var localModel = await _context.Local
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localModel == null)
            {
                return NotFound();
            }

            return View(localModel);
        }

        // POST: Local/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Local == null)
            {
                return Problem("Entity set 'Contexto.Local'  is null.");
            }
            var localModel = await _context.Local.FindAsync(id);
            if (localModel != null)
            {
                _context.Local.Remove(localModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalModelExists(int id)
        {
          return (_context.Local?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
