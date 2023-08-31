using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Repositorio.Interface
{
    public interface IAlunoRepositorio
    {
        List<Aluno> BuscarAlunos();

        void InserirAluno(Aluno aluno);

        void AtualizarDadosAluno(Aluno aluno);

        void ExcluirAluno(Aluno aluno);

        Aluno BuscarId(int id);

        bool Logar(string nome, string cep);
    }
}
