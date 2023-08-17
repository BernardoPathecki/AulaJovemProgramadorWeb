using JovemProgramadorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using JovemProgramadorWeb.Data.Repositorio.Interface;

namespace JovemProgramadorWeb.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IConfiguration configuration, IAlunoRepositorio alunoRepositorio) 
        {
            _configuration = configuration;
            _alunoRepositorio = alunoRepositorio;
        }

        public IActionResult Aluno() 
        { 
            var aluno = _alunoRepositorio.BuscarAlunos();
            return View(aluno);
        }
        #region Adicionar Aluno
        public IActionResult AdicionarAluno()
        {
            return View();
        }

        public IActionResult InserirAluno(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.InserirAluno(aluno);
            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = "Erro ao inserir aluno";
            }

            TempData["MsgSucesso"] = "Aluno adicionado com sucesso!";
            return RedirectToAction("Aluno");

        }
        #endregion

        #region Atualizar Dados
        public IActionResult EditarAluno(int id)
        {
            var idAluno = _alunoRepositorio.BuscarId(id);
            return View("EditarAluno", idAluno);
        }

        public IActionResult AtualizarDadosAluno(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.AtualizarDadosAluno(aluno);
            }catch (Exception ex)
            {

            }
            return RedirectToAction("Aluno");
        }
        #endregion

        public IActionResult ExcluirAluno(Aluno aluno)
        {
            _alunoRepositorio.ExcluirAluno(aluno);
            return RedirectToAction("Aluno");
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
