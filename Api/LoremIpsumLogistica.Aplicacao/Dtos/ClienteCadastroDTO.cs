using LoremIpsumLogistica.Dominio.Constantes;

namespace LoremIpsumLogistica.Aplicacao.Dtos
{
    public class ClienteCadastroDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public TipoDeClienteSexo TipoDeClienteSexo { get; set; }
    }
}
