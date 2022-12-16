using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestDB;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private TestContext _context;

        public ClienteController(TestContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Cliente> Get() => _context.Clientes.ToList();

    }
}
