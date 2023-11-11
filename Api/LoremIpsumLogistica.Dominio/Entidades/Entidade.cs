using LoremIpsumLogistica.Dominio.Interfaces;

namespace LoremIpsumLogistica.Dominio.Entidades
{
    public class Entidade : IEntidade
    {
        protected Entidade() { }
        public int Id { get; set; }
        public DateTime DataDeCadastro { get; set; } 
        public DateTime? DataDeAlteracao { get; set; } 


        public virtual void Validar()
        {
        }
    }
}
