using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Repositorio.Interface
{
    public interface IAlunoRepositorio
    {
        List<Aluno> BuscarAlunos();

        void InserirAluno(Aluno aluno);
    }
}
