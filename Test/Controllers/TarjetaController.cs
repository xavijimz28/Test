using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestDB;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private TestContext _context;
        public TarjetaController(TestContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Tarjeta> Get() => _context.Tarjetas.ToList();
        //cambio
    }
}
