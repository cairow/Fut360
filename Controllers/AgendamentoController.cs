using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fut360.Data;
using Fut360.Models;
using Microsoft.AspNetCore.Authorization;

namespace Fut360.Controllers
{
    public class AgendamentoController : Controller
    {
  
        private readonly Contexto _context;

        public AgendamentoController(Contexto context)
        {
            _context = context;
        }

        // GET: Agendamento
        public async Task<IActionResult> Index()
        {
              return _context.AgendamentoModel != null ? 
                          View(await _context.AgendamentoModel.ToListAsync()) :
                          Problem("Entity set 'Contexto.AgendamentoModel'  is null.");
        }

        // GET: Agendamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AgendamentoModel == null)
            {
                return NotFound();
            }

            var agendamentoModel = await _context.AgendamentoModel
                .FirstOrDefaultAsync(m => m.localModel.Id == id);
            if (agendamentoModel == null)
            {
                return NotFound();
            }

            return View(agendamentoModel);
        }

        // GET: Agendamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agendamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,HorarioDisponivel,HorarioReservado")] AgendamentoModel agendamentoModel)
        {
            

            if (ModelState.IsValid)
            {
                _context.Add(agendamentoModel);
                await _context.SaveChangesAsync();

                

                return RedirectToAction(nameof(Index));
            }
            return View(agendamentoModel);
        }

        // GET: Agendamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AgendamentoModel == null)
            {
                return NotFound();
            }

            var agendamentoModel = await _context.AgendamentoModel.FindAsync(id);
            if (agendamentoModel == null)
            {
                return NotFound();
            }
            return View(agendamentoModel);
        }

        // POST: Agendamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,HorarioDisponivel,HorarioReservado")] AgendamentoModel agendamentoModel)
        {
            if (id != agendamentoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendamentoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamentoModelExists(agendamentoModel.Id))
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
            return View(agendamentoModel);
        }

        // GET: Agendamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AgendamentoModel == null)
            {
                return NotFound();
            }

            var agendamentoModel = await _context.AgendamentoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendamentoModel == null)
            {
                return NotFound();
            }

            return View(agendamentoModel);
        }

        // POST: Agendamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AgendamentoModel == null)
            {
                return Problem("Entity set 'Contexto.AgendamentoModel'  is null.");
            }
            var agendamentoModel = await _context.AgendamentoModel.FindAsync(id);
            if (agendamentoModel != null)
            {
                _context.AgendamentoModel.Remove(agendamentoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamentoModelExists(int id)
        {
          return (_context.AgendamentoModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
