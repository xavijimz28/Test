using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestDB;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionPagoController : ControllerBase
    {
        private TestContext _context;
        public TransaccionPagoController(TestContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<TransaccionPago> Get() => _context.TransaccionPagos.ToList();
    }
}
