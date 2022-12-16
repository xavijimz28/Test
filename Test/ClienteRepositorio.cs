using Microsoft.EntityFrameworkCore;
using TestDB;
using static Test.Interfaz;

namespace Test
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        protected readonly TestContext _context;
        public ClienteRepositorio(TestContext context) => _context = context;


        public Cliente GetClienteById(Guid ClienteId)
        {
            return _context.Clientes.Find(ClienteId);
        }

        public async Task<Cliente> CreateClienteAsync(Cliente cliente)
        {
            await _context.Set<Cliente>().AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> UpdateClienteAsync(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;

        }

        public Task<bool> DeleteProductAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Clientes.ToList();
        }
        public IEnumerable<CuentaCliente> GetCuentaByEstatusActivo()
        {
            return _context.CuentasClientes.Where(d => d.Activo == true).ToList();
        }
        public IEnumerable<Tarjeta> GetTarjetaCredito()
        {
            return _context.Tarjetas.Where(d => d.TipoTarjeta == 1).ToList();
        }
    }
}
