namespace LoremIpsumLogistica.UI.Api.Models
{
    public class ClienteEnderecoCadastroModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public bool Comercial { get; set; }

    }
}
 