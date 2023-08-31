using JovemProgramadorWeb.Data.Repositorio.Interface;
using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public AlunoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public List<Aluno> BuscarAlunos()
        {
            return _bancoContexto.Aluno.ToList();
        }

        public void InserirAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Add(aluno);
            _bancoContexto.SaveChanges();
        }
        
        public Aluno BuscarId(int id)
        {
            return _bancoContexto.Aluno.Find(id);
        }

        public void AtualizarDadosAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Update(aluno);
            _bancoContexto.SaveChanges();
        }

        public void ExcluirAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Remove(aluno);
            _bancoContexto.SaveChanges();
        }

        public bool Logar(string nome, string cep)
        {
            var usuario = _bancoContexto.Aluno.FirstOrDefault(u => u.nome == nome && u.cep == cep);
            if (usuario == null) 
            {
            return false;
            }
            return true;
        }
    }
}
