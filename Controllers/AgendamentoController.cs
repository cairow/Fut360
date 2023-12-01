using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fut360.Data;
using Fut360.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Humanizer;

namespace Fut360.Controllers
{
    [Produces("application/json")]
    public class AgendamentoController : Controller
    {

        private readonly Contexto _context;

        public AgendamentoController(Contexto context)
        {
            _context = context;
        }

        // GET : Aprovador
        public async Task<IActionResult> Aprovador(AgendamentoModel agendamentoModel)
        {
            //pega ID do usuario logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //pega o Id do local
            agendamentoModel.localModel = await _context.LocalModel.FindAsync(agendamentoModel.Id) ?? new();

            // Filtra os agendamentos pelo ID do usuário
            var agendamentosDoAprovador = await _context.AgendamentoModel
                .Where(a => a.localModel.Aprovador.Id == userId)
                .Include(a => a.localModel)
                .Include(u => u.userModel)
                .ToListAsync();

            return agendamentosDoAprovador != null ?
             View(agendamentosDoAprovador) :
             Problem("Entity set 'Contexto.AgendamentoModel' is null.");
        
        }

        // GET : Aprovado
        public IActionResult Aprovado(AgendamentoModel agendamentoModel)
        {
            var agendamentoId = HttpContext.Request.Path.Value?.Split('/').Last();
            var agendamento = _context.AgendamentoModel.Find(int.Parse(agendamentoId ?? "")) ?? new();
            agendamento.Aprovado = true;
            _context.AgendamentoModel.Update(agendamento);
            _context.SaveChanges();

            return RedirectToAction(nameof(Aprovador));
        }

        // GET : Desaprovado
        public IActionResult Desaprovado(AgendamentoModel agendamentoModel)
        {
            var agendamentoId = HttpContext.Request.Path.Value?.Split('/').Last();
            var agendamento = _context.AgendamentoModel.Find(int.Parse(agendamentoId ?? "")) ?? new();
            _context.AgendamentoModel.Remove(agendamento);
            _context.SaveChanges();

            return RedirectToAction(nameof(Aprovador));
        }

        // GET: Agendamento
        public async Task<IActionResult> Index(AgendamentoModel agendamentoModel)
        {
            //pega ID do usuario logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //pega o Id do local
            agendamentoModel.localModel = await _context.FindAsync<LocalModel>(agendamentoModel.Id) ?? new();

            // Filtra os agendamentos pelo ID do usuário
            var agendamentosDoUsuario = await _context.AgendamentoModel
                .Where(a => a.userModel.Id == userId)
                .Include(a => a.localModel)
                .ToListAsync();

            return agendamentosDoUsuario != null ?
             View(agendamentosDoUsuario) :
             Problem("Entity set 'Contexto.AgendamentoModel' is null.");
            //return _context.AgendamentoModel != null ?
            //                View(await _context.AgendamentoModel.Include(a => a.localModel).ToListAsync()) :
            //                Problem("Entity set 'Contexto.AgendamentoModel'  is null.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendamentoModel>>> GetEvents([FromQuery] DateTime HoraInicial, [FromQuery] DateTime HoraFinal)
        {
            return await _context.AgendamentoModel
                .Where(e => !((e.DataHoraFinal <= HoraInicial) || (e.DataHoraInicial >= HoraFinal)))
                .ToListAsync();
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
        public async Task<IActionResult> Create(int id)
        {
            Console.WriteLine(id);
            List<HorarioModel> horarios = _context.Horarios.ToList();
            List<LocalModel> locais = _context.LocalModel.ToList();

            ViewData["horarios"] = horarios;
            ViewData["locais"] = locais;
            ViewData["idLocal"] = id;


            return View();
        }

        // POST: Agendamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgendamentoModel agendamentoModel)
        {
            var data = HttpContext.Request;
            
            var date = data.Form["data"][0];
            var horaInicial = data.Form["DataHoraInicial"][0];
            var horaFinal = data.Form["DataHoraFinal"][0];

            agendamentoModel.DataHoraInicial = DateTime.Parse($"{date} {horaInicial}");
            agendamentoModel.DataHoraFinal = DateTime.Parse($"{date} {horaFinal}");

            var now = DateTime.Now;

            if (agendamentoModel.DataHoraInicial <= now || agendamentoModel.DataHoraFinal <= now)
            {
                ModelState.AddModelError(string.Empty, "Horário inicial deve ser menor que o horário final.");
                return BadRequest("Horario inicial/final não pode estar no passado.");
            }

            if (agendamentoModel.DataHoraInicial >= agendamentoModel.DataHoraFinal)
            {
                ModelState.AddModelError(string.Empty, "Horario inicial deve ser menor que o horario final.");
                return BadRequest("Horario inicial deve ser menor que o horario final.");
            }

            if (agendamentoModel.DataHoraInicial <= agendamentoModel.DataHoraInicial.AtMidnight().AddHours(5) || agendamentoModel.DataHoraFinal <= agendamentoModel.DataHoraFinal.AtMidnight().AddHours(6))
            {
                ModelState.AddModelError(string.Empty, "Agendamentos são permitidos apenas depois das 6 da manhã.");
                return BadRequest("Agendamentos são permitidos apenas depois das 6 da manhã.");
            }

            if (agendamentoModel.DataHoraInicial >= agendamentoModel.DataHoraInicial.AtMidnight().AddHours(24) || agendamentoModel.DataHoraFinal >= agendamentoModel.DataHoraFinal.AtMidnight().AddHours(23))
            {
                ModelState.AddModelError(string.Empty, "Agendamentos são permitidos apenas antes da 00 da noite.");
                return BadRequest("Agendamentos são permitidos apenas antes da 00 da noite.");
            }

            var agendamentos = _context.AgendamentoModel.Where(a => a.localModel.Id == agendamentoModel.Id);

            foreach (var agendamento in agendamentos)
            {
                if (agendamentoModel.DataHoraInicial >= agendamento.DataHoraInicial && agendamentoModel.DataHoraInicial <= agendamento.DataHoraFinal ||
                     agendamentoModel.DataHoraFinal >= agendamento.DataHoraInicial && agendamentoModel.DataHoraFinal <= agendamento.DataHoraFinal)
                {
                    ModelState.AddModelError(string.Empty, $"Já existe um agendamento nesse horário: {agendamento.DataHoraInicial} - {agendamento.DataHoraFinal} que conflita com o agendamento pedido, favor escolher outro horário.");
                    return BadRequest($"Já existe um agendamento nesse horário: {agendamento.DataHoraInicial} - {agendamento.DataHoraFinal} que conflita com o agendamento pedido, favor escolher outro horário.");
                }
            }

            var ErrorMessage = ViewData["BadRequest"];

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
