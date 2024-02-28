using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fut360.Data;
using Fut360.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Fut360.Controllers
{
    [Authorize(Roles = "Admin, User, Aprovador")]

    public class LocalController : Controller
    {
        private readonly Contexto _context;

        private readonly string caminhoServidor;

        private readonly UserManager<IdentityUser> _userManager;


        public LocalController(Contexto context, IWebHostEnvironment sistema, UserManager<IdentityUser> userManager)
        {
            _context = context;
            caminhoServidor = sistema.WebRootPath;
            _userManager = userManager;

        }

        // GET: Local
        public async Task<IActionResult> Index()
        {

            return _context.LocalModel != null ?
                        View(await _context.LocalModel.ToListAsync()) :
                        Problem("Entity set 'Contexto.local'  is null.");
        }

        // GET: Local/Details/5
        //[Authorize(Roles  = "User, Admin, Aprovador")]
        [Authorize(Policy = "RequireUserAdminAprovadorRole")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LocalModel == null)
            {
                return NotFound();
            }

            var localModel = await _context.LocalModel
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
            List<IdentityUser> usuarios = _userManager.Users.ToList();

            ViewData["usuarios"] = usuarios;

            return View();
        }

        // POST: Local/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User, Admin, Aprovador")]
        public async Task<IActionResult> Create(LocalModel localModel)
        {
            var foto = HttpContext.Request.Form.Files[0];
            var aprovador = HttpContext.Request.Form["Aprovador"][0];
            localModel.Aprovador = _userManager.Users.ToList().Find((user) => user.Id == aprovador);

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

        [Authorize(Roles = "Admin")]
        // GET: Local/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<IdentityUser> usuarios = _userManager.Users.ToList();

            ViewData["usuarios"] = usuarios;

            if (id == null || _context.LocalModel == null)
            {
                return NotFound();
            }

            var localModel = await _context.LocalModel.FindAsync(id);
            if (localModel == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: Local/Edit/5
        [Authorize(Roles = "Admin")]
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
            if (id == null || _context.LocalModel == null)
            {
                return NotFound();
            }

            var localModel = await _context.LocalModel
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
            if (_context.LocalModel == null)
            {
                return Problem("Entity set 'Contexto.Local'  is null.");
            }
            var localModel = await _context.LocalModel.FindAsync(id);
            if (localModel != null)
            {
                _context.LocalModel.Remove(localModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalModelExists(int id)
        {
            return (_context.LocalModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
