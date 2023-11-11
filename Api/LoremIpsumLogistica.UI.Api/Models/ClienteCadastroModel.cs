using LoremIpsumLogistica.Dominio.Constantes;

namespace LoremIpsumLogistica.UI.Api.Models
{
    public class ClienteCadastroModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public TipoDeClienteSexo TipoDeClienteSexo { get; set; }

    }
}
 