using Fut360.Data;
using Fut360.Helper;
using Fut360.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fut360.Controllers
{
    public class LoginController : Controller
    {
        private readonly Contexto _context;
        private readonly ISessao _sessao;

        public LoginController(Contexto context, ISessao sessao)
        {
            _context = context;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            // Se o usuario estiver logado, redirecionar paga a home

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();

            return RedirectToAction("Index", "Login");
        }


        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel) 
        { 
            try
            {
                if (ModelState.IsValid) 
                {

                    // tenho que pegar o login pra comparar
                    UsuarioModel usuario = _context.(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"A senha do usuário é inválida. Por favor, tente novamente.";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";

                }

                return View("Index");
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
