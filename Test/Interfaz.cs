using TestDB;

namespace Test
{
    public class Interfaz
    {
        public interface IClienteRepositorio
        {
            Task<Cliente> CreateClienteAsync(Cliente cliente);
            Task<bool> DeleteProductAsync(Cliente cliente);
            Cliente GetClienteById(Guid ClienteId);
            IEnumerable<Cliente> GetClientes();
            Task<bool> UpdateClienteAsync(Cliente cliente);
        }
    }
}
