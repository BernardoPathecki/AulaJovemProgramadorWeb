using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Mapeamento
{
    public class AlunoMapeamento : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno>builder)
        {
            builder.ToTable("AlunoWeb");
            builder.HasKey(t => t.id);
            builder.Property(t => t.nome).HasColumnType("varchar(50)");
            builder.Property(t => t.nota).HasColumnType("decimal(4.2)");
            builder.Property(t => t.situacao).HasColumnType("varchar(50)");
            builder.Property(t => t.cep).HasColumnType("char(9)");
        }
    }
}
