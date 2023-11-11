using LoremIpsumLogistica.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoremIpsumLogistica.Infraestrutura.Repositorio.Context.Configuracoes
{
    public class ClienteDbConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.Property(m => m.Nome).HasMaxLength(150);
            builder.Property(m => m.DataDeNascimento);
            builder.Property(m => m.TipoDeClienteSexo);


            builder.Property(m => m.DataDeCadastro).IsRequired();
        }
    }
}
