using LoremIpsumLogistica.Dominio.Constantes;

namespace LoremIpsumLogistica.UI.Api.Models
{
    public class ClienteModel : EntidadeModel
    {
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public TipoDeClienteSexo TipoDeClienteSexo { get; set; }

    }
}
 