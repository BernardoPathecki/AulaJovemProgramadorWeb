using Microsoft.AspNetCore.Mvc;
namespace JovemProgramadorWeb.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Aluno() 
        { 
            return View();
        }
    }
}
