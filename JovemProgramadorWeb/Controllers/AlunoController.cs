using JovemProgramadorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JovemProgramadorWeb.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;

        public AlunoController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public IActionResult Aluno() 
        { 
            return View();
        }
        public IActionResult AdicionarAluno()
        {
            return View();
        }

        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            Endereco endereco = new Endereco();

            try 
            {
                cep = cep.Replace("-", "");

                using var client = new HttpClient();
                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"]+ cep + "/json");
                if (result.IsSuccessStatusCode)
                {
                    endereco = JsonSerializer.Deserialize<Endereco>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions());
                    
                }
                else
                {
                    ViewData["MsgErro"] = "Erro na busca do endereço!";
                }
            } 
            catch (Exception ex) 
            { 
                throw; 
            }
            ViewData["MsgSucesso"] = "Busca feita com sucesso!";
            return View("Endereco", endereco);
        }
    }
}
