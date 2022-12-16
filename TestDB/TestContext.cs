using Microsoft.EntityFrameworkCore;

namespace TestDB
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
           : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CuentaCliente> CuentasClientes { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<TransaccionPago> TransaccionPagos { get; set; }
        public DbSet<TarjetaPrestamo> TarjetaPrestamos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<CuentaCliente>().ToTable("CuentaCliente");
            modelBuilder.Entity<Tarjeta>().ToTable("Tarjeta");
            modelBuilder.Entity<TransaccionPago>().ToTable("TransaccionPago");
            modelBuilder.Entity<TarjetaPrestamo>().ToTable("TarjetaPrestamo");
        }

    }
}