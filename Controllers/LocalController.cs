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
    [Authorize]
    public class LocalController : Controller
    {
        private readonly Contexto _context;

        private readonly string caminhoServidor;

        public LocalController(Contexto context, IWebHostEnvironment sistema)
        {
            _context = context;
            caminhoServidor = sistema.WebRootPath;
        }

        // GET: Local
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return _context.Local != null ?
                        View(await _context.Local.ToListAsync()) :
                        Problem("Entity set 'Contexto.local'  is null.");
        }

        // GET: Local/Details/5
        //[Authorize(Roles  = "User, Admin, Aprovador")]
        [Authorize(Policy = "RequireUserAdminAprovadorRole")]
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
        //[Authorize(Roles = "User, Admin, Aprovador")]
        [Authorize(Policy = "RequireUserAdminAprovadorRole")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Local/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User, Admin, Aprovador")]
        public async Task<IActionResult> Create(LocalModel localModel)
        {
            var foto = HttpContext.Request.Form.Files[0];

            if (ModelState.IsValid)
            {
                if (foto != null && foto.Length > 0)
                {
                    //salvar foto
                    string caminhoParaSalvarImagem = caminhoServidor + "\\fotos\\";
                    string novoNomeParaImagem = Guid.NewGuid().ToString() + "_" + foto.FileName;

                    if (!Directory.Exists(caminhoParaSalvarImagem))
                    {
                        Directory.CreateDirectory(caminhoParaSalvarImagem);
                    }

                    using (var stream = System.IO.File.Create(caminhoParaSalvarImagem + novoNomeParaImagem))
                    {
                        await foto.CopyToAsync(stream);
                    }

                    localModel.ImagemLocal = novoNomeParaImagem;
                }

                _context.Add(localModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(localModel);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        // POST: Local/Edit/5
        [Authorize(Roles = "Admin, Aprovador")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
