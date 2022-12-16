using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestDB;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaClienteController : ControllerBase
    {
        private TestContext _context;
        public CuentaClienteController(TestContext context)
        {
            _context = context;
        }
        //[HttpGet]
        //public IEnumerable<CuentaCliente> Get() => _context.CuentasClientes.ToList();
        [HttpGet]
        public IEnumerable<CuentaCliente> GetCuentasByStatus() => _context.CuentasClientes.Where(cuenta => cuenta.Activo == true).ToList();
    }
}
