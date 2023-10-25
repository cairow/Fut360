using Fut360.Data;
using Fut360.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fut360.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly Contexto _context;

        public UsuarioController(Contexto context)
        {
            _context = context;
        }
        // GET: Usuario/BuscarPorLogin
        public IActionResult BuscarPorLogin(string login)
        {
            if (login == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuarioModel = _context.Usuario.FirstOrDefaultAsync(m => m.Login.ToUpper() == login.ToUpper());

            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            return _context.Usuario != null ?
                        View(await _context.Usuario.ToListAsync()) :
                        Problem("Entity set 'Usuario'  is null.");
        }
        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Usuario.FirstOrDefaultAsync(m => m.Id == id);

            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Login,Email,Contato, Senha")] UsuarioModel usuarioModel)
        {
                if (ModelState.IsValid)
                {
                    _context.Add(usuarioModel);
                    await _context.SaveChangesAsync();
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";

                    return RedirectToAction(nameof(Index));
                }
                return View(usuarioModel);
            
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Usuario.FindAsync(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            return View(usuarioModel);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Login,Email,Contato,Senha")] UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (UsuarioModelExists(usuarioModel.Id))
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
            return View(usuarioModel);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'Contexto.Usuario'  is null.");
            }
            var usuarioModel = await _context.Usuario.FindAsync(id);
            if (usuarioModel != null)
            {
                _context.Usuario.Remove(usuarioModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioModelExists(int id)
        {
            return (_context.Usuario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
