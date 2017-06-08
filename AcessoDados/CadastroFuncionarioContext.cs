using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Negocio;


namespace AcessoDados
{
    public class CadastroFuncionarioContext : DbContext
    {
        public CadastroFuncionarioContext() : base("CadastroFuncionario")
        {
        }
        
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Beneficio> Beneficios { get; set; }
        public DbSet<Area> Areas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Beneficio>().HasMany(e => e.Funcionarios).WithMany(e => e.Beneficios);
        }
    }
}
