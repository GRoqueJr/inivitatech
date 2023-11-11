using LoremIpsumLogistica.Dominio.Constantes;

namespace LoremIpsumLogistica.Dominio.Entidades
{
    public class Cliente : Entidade 
    {
        protected Cliente() { }

        public Cliente(string nome, DateTime dataDeNascimento, TipoDeClienteSexo tipoDeClienteSexo) {
            
            this.SetarTipoDeClienteSexo(tipoDeClienteSexo);
            this.SetarNome(nome);
            this.SetarDataDeNascimento(dataDeNascimento);

            this.SetarDataDeCadastro();
        }


        public string Nome { get; private set; }
        public DateTime DataDeNascimento { get; private set; } 
        public TipoDeClienteSexo TipoDeClienteSexo { get; private set; }

        public ICollection<ClienteEndereco> Enderecos { get; private set; } = new List<ClienteEndereco>();


        #region Métodos

        public void SetarNome(string nome) { this.Nome = nome == null ? string.Empty : nome; }
        public void SetarDataDeNascimento(DateTime dataDeNascimento) { this.DataDeNascimento = dataDeNascimento; }
        public void SetarTipoDeClienteSexo(TipoDeClienteSexo tipoDeClienteSexo) { this.TipoDeClienteSexo = tipoDeClienteSexo; }
        public void SetarDataDeCadastro() { this.DataDeCadastro = DateTime.UtcNow; }
        public void SetarDataDeAlteracao() { this.DataDeAlteracao = DateTime.UtcNow; }


        public virtual void Validar()
        {
            if (this.Nome == "")
            {
                throw new Exception("O nome não pode ser vazio");
            }
        }

        #endregion
    }
}
