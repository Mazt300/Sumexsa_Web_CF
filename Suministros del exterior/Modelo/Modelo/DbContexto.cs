using Microsoft.EntityFrameworkCore;
using Modelo.Modelo.TablasCatalogo;

namespace Modelo.Modelo
{
    public class DbContexto : DbContext
    {
        public DbContexto()
        {

        }

        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {

        }
        public virtual DbSet<ClienteImportador> ClienteImportador { get; set; }
        public virtual DbSet<PersonaContacto> PersonaContacto { get; set; }
        public virtual DbSet<ClienteProveedor> ClienteProveedor { get; set; }
        public virtual DbSet<BancoProveedor> BancoProveedor { get; set; }
        public virtual DbSet<BancoInternacional> BancoInternacional { get; set; }

        //Utilizar este metodo en la clase si el contexto no esta en el mismo proyecto
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        { 
            if (!optionBuilder.IsConfigured)
            {
                ConnectionString connection = new ConnectionString();
                optionBuilder.UseSqlServer(connection.conexion().ToString());
            }
        }

    }
}
