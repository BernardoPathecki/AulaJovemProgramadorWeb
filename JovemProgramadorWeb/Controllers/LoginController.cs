using JovemProgramadorWeb.Data;
using JovemProgramadorWeb.Data.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly BancoContexto _bancoContexto;
        public LoginController(IAlunoRepositorio alunoRepositorio, BancoContexto bancoContexto)
        {
            _alunoRepositorio = alunoRepositorio;
            _bancoContexto = bancoContexto;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logar(string nome, string cep)
        {
            var usuario = _alunoRepositorio.Logar(nome, cep);
            if (usuario == true) 
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["MsgErro"] = "Nome ou CEP inválidos!";
            return View("Login");
        }

    }
}
