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
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using MvcWebIdentity.Areas.Admin.Controllers;
using Humanizer;

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
                        View(await _context.AgendamentoModel.Include(a => a.localModel).ToListAsync()) :
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
        public async Task<IActionResult> Create(AgendamentoModel agendamentoModel)
        {
            var now = DateTime.Now;

            if (agendamentoModel.DataHoraInicial <= now || agendamentoModel.DataHoraFinal <= now)
            {
                return BadRequest("Horario inicial/final não pode estar no passado.");
            }

            if (agendamentoModel.DataHoraInicial >= agendamentoModel.DataHoraFinal)
            {
                return BadRequest("Horario inicial deve ser menor que o horario final.");
            }

            if (agendamentoModel.DataHoraInicial <= agendamentoModel.DataHoraInicial.AtMidnight().AddHours(6) || agendamentoModel.DataHoraFinal <= agendamentoModel.DataHoraFinal.AtMidnight().AddHours(6))
            {
                return BadRequest("Agendamentos são permitidos apenas depois das 6 da manhã.");
            }

            if (agendamentoModel.DataHoraInicial >= agendamentoModel.DataHoraInicial.AtMidnight().AddHours(23) || agendamentoModel.DataHoraFinal >= agendamentoModel.DataHoraFinal.AtMidnight().AddHours(23))
            {
                return BadRequest("Agendamentos são permitidos apenas antes das 11 da noite.");
            }

            var agendamentos = _context.AgendamentoModel.Where(a => a.localModel.Id == agendamentoModel.Id);

            foreach (var agendamento in agendamentos)
            {
                if (agendamentoModel.DataHoraInicial >= agendamento.DataHoraInicial && agendamentoModel.DataHoraInicial <= agendamento.DataHoraFinal ||
                     agendamentoModel.DataHoraFinal >= agendamento.DataHoraInicial && agendamentoModel.DataHoraFinal <= agendamento.DataHoraFinal)
                {
                    return BadRequest($"Já existe um agendamento nesse horário: {agendamento.DataHoraInicial} - {agendamento.DataHoraFinal} que conflita com o agendamento pedido, favor escolher outro horário.");
                }
            }

            //pega ID do usuario logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            agendamentoModel.userModel = await _context.FindAsync<IdentityUser>(userId) ?? new();
            //pega o Id do local
            agendamentoModel.localModel = await _context.FindAsync<LocalModel>(agendamentoModel.Id) ?? new();
            agendamentoModel.Id = 0;
            agendamentoModel.Aprovado = false;

            _context.Add(agendamentoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
