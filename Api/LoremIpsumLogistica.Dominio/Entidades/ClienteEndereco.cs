namespace LoremIpsumLogistica.Dominio.Entidades
{
    public class ClienteEndereco : Entidade
    {
        public int ClienteId { get; private set; }
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }
        public bool Comercial { get; private set; }

        #region Construtores

        protected ClienteEndereco() { }

        public ClienteEndereco(int clienteId,
            string cep,
            string logradouro,
            string numero,
            string complemento,
            string bairro,
            string cidade,
            string uf,
            bool comercial)
        {
            this.SetarClienteId(clienteId);
            this.SetarCep(cep);
            this.SetarLogradouro(logradouro);
            this.SetarNumero(numero);
            this.SetarComplemento(complemento);
            this.SetarBairro(bairro);
            this.SetarCidade(cidade);
            this.SetarUf(uf);
            this.SetarComercial(comercial);

            this.SetarDataDeCadastro();
        }

        #endregion

        #region Métodos


        public void SetarClienteId(int clienteId) { this.ClienteId = clienteId; }
        public void SetarCep(string cep) { this.Cep = cep == null ? string.Empty : cep; }
        public void SetarLogradouro(string logradouro) { this.Logradouro = logradouro == null ? string.Empty : logradouro; }
        public void SetarNumero(string numero) { this.Numero = numero == null ? string.Empty : numero; }
        public void SetarComplemento(string complemento) { this.Complemento = complemento == null ? string.Empty : complemento; }
        public void SetarBairro(string bairro) { this.Bairro = bairro == null ? string.Empty : bairro; }
        public void SetarCidade(string cidade) { this.Cidade = cidade == null ? string.Empty : cidade; }
        public void SetarUf(string uf) { this.Uf = uf == null ? string.Empty : uf.ToUpper(); }
        public void SetarComercial(bool comercial) { this.Comercial = comercial; }
        public void SetarDataDeCadastro() { this.DataDeCadastro = DateTime.UtcNow; }
        public void SetarDataDeAlteracao() { this.DataDeAlteracao = DateTime.UtcNow; }


        public virtual void Validar()
        {
            if (this.ClienteId < 0)
            {
                throw new Exception("Cliente inválido");
            }

            if (this.Cep == "")
            {
                throw new Exception("Cep é obrigatório");
            }

            if (this.Cep.Length != 8)
            {
                throw new Exception("Cep inválido");
            }

            if (this.Numero == "")
            {
                throw new Exception("Número é obrigatório");
            }

            if (this.Cidade == "")
            {
                throw new Exception("Número é obrigatório");
            }

            if (this.Uf == "")
            {
                throw new Exception("Número é obrigatório");
            }

        }
        #endregion

    }
}
