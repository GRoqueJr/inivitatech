using LoremIpsumLogistica.Dominio.Entidades;
using LoremIpsumLogistica.Infraestrutura.Repositorio.Context.Configuracoes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LoremIpsumLogistica.Infraestrutura.Repositorio.Context
{
    public class LoremDbContext : DbContext
    {
        public  LoremDbContext(DbContextOptions<LoremDbContext> options) : base(options) { }


        #region DbSets

        
        #region C
        public DbSet<Cliente> Clientes { get; set; }
        #endregion C



        #region E
        public DbSet<ClienteEndereco> ClientesEnderecos { get; set; }
        #endregion E



        #endregion DbSets



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            
            #region C
            modelBuilder.Entity<Cliente>(new ClienteDbConfiguration().Configure);
            #endregion C


            #region E
            modelBuilder.Entity<ClienteEndereco>(new ClienteEnderecoDbConfiguration().Configure);
            #endregion E

        }

        public override int SaveChanges()
        {
            var entities = (from entry in ChangeTracker.Entries()
                            where entry.State == EntityState.Modified || entry.State == EntityState.Added
                            select entry.Entity);

            var validationResults = new List<ValidationResult>();
            foreach (var entity in entities)
            {
                if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults))
                {
                    throw new ValidationException();
                }
            }
            return base.SaveChanges();
        }

        public void UnSaveChanges()
        {
            foreach (var entry in base.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        {
                            entry.CurrentValues.SetValues(entry.OriginalValues);
                            entry.State = EntityState.Unchanged;

                            break;
                        }
                    case EntityState.Deleted:
                        {
                            entry.State = EntityState.Unchanged;

                            break;
                        }
                    case EntityState.Added:
                        {
                            entry.State = EntityState.Detached;

                            break;
                        }
                }
            }
        }

    }
}
