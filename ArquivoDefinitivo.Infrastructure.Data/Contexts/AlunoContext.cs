using ArquivoDefinitivo.Common.Infrastructure.Data;
using System.Data.Entity;
using ArquivoDefinitivo.Domain.Entities;

namespace ArquivoDefinitivo.Infrastructure.Data.Contexts
{
    public class AlunoContext : ArquivoDefinitivoCommonDbContext 
    {
        static AlunoContext()
        {
            Database.SetInitializer<AlunoContext>(null);
        }

        public AlunoContext() 
            : base("")
        {
        }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Properties<string>().Configure(c => c.IsUnicode(false));

            modelBuilder.Configurations.AddFromAssembly(typeof(AlunoContext).Assembly);
        }
    }
}
