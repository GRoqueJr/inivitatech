using LoremIpsumLogistica.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoremIpsumLogistica.Infraestrutura.Repositorio.Context.Configuracoes
{
    public class ClienteEnderecoDbConfiguration : IEntityTypeConfiguration<ClienteEndereco>
    {
        public void Configure(EntityTypeBuilder<ClienteEndereco> builder)
        {
            builder.ToTable("ClientesEnderecos");

            builder.Property(m => m.ClienteId).IsRequired();
            builder.Property(m => m.Cep).HasMaxLength(8).IsRequired();
            builder.Property(m => m.Logradouro).HasMaxLength(150).IsRequired();
            builder.Property(m => m.Numero).HasMaxLength(50).IsRequired();
            builder.Property(m => m.Complemento).HasMaxLength(150);
            builder.Property(m => m.Bairro).HasMaxLength(100);
            builder.Property(m => m.Cidade).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Uf).HasMaxLength(2).IsRequired();
            builder.Property(m => m.Comercial).IsRequired();

            builder.Property(m => m.DataDeCadastro).IsRequired();
        }
    }
}
