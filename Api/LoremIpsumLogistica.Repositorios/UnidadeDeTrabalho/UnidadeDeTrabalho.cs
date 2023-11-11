using LoremIpsumLogistica.Dominio.Interfaces.UnidadeDeTrabalho;
using LoremIpsumLogistica.Infraestrutura.Repositorio.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoremIpsumLogistica.Infraestrutura.Repositorio.UnidadeDeTrabalho
{
    public class UnidadeDeTrabalho : IUnidadeDeTrabalho
    {
        private readonly LoremDbContext context;
        private IDbContextTransaction transacao { get; set; }
        public bool UnidadeInicializada { get; private set; }

        public UnidadeDeTrabalho(LoremDbContext context)
        {
            this.context = context;
        }

        public void Iniciar()
        {
            this.UnidadeInicializada = true;
            this.transacao = this.context.Database.BeginTransaction();
#if GILBERTO
#elif DEBUG
            System.Diagnostics.Debug.WriteLine("Inicializando a unidade de trabalho");
#endif
        }

        public bool Inicializada()
        {
            return this.UnidadeInicializada;
        }

        public bool CheckPoint()
        {
            if (this.UnidadeInicializada)
            {
                try
                {
                    var linhas = this.context.SaveChanges();
#if GILBERTO
#elif DEBUG
                    System.Diagnostics.Debug.WriteLine("Unidde de trabalho - CheckPoint - Concluído");
                    System.Diagnostics.Debug.WriteLine("Linhas afetadas: " + linhas.ToString());
#endif
                }
                catch (ValidationException e)
                {


                    var msg = new StringBuilder();
                    foreach (var error in e.Data)
                    {
                        msg.AppendLine(error.ToString());
                        System.Diagnostics.Debug.WriteLine("Erro na conclusão do CheckPoint da unidade de trabalho" + error.ToString());
                    }

                    this.DesfazerCheckPoint();
                    throw new Exception("Erro na conclusão da unidade de trabalho");
                }

                return true;
            }
            else
            {
                throw new Exception("A unidade de trabalho não foi inicializada");
            }
        }

        private void DesfazerCheckPoint()
        {
            this.UnidadeInicializada = false;
            this.context.UnSaveChanges();
        }

        public bool ConcluirTransacao()
        {
            if (this.UnidadeInicializada)
            {
                var ok = true;

                try
                {
                    this.transacao.Commit();
#if GILBERTO
#elif DEBUG
                    System.Diagnostics.Debug.WriteLine("Unidade de trabalho - Transação concluída");
#endif
                }
                catch (Exception ex)
                {
                    DesfazerTransacao();
                    ok = false;
                }
                finally
                {
                    this.UnidadeInicializada = false;
                }

                return (ok);
            }
            else
            {
                throw new Exception("A unidade de trabalho não foi inicializada");
            }
        }

        public void DesfazerTransacao()
        {
            this.transacao.Rollback();
            Console.WriteLine("Unidade de trabalho - Transação concluída com erro - RollBack executado.");
        }

        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }
    }
}
