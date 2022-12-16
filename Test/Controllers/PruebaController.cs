using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestDB;
using static Test.Interfaz;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        //No haz hecho la interfaz no
        private IClienteRepositorio _clienteRepositorio;
        public PruebaController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpGet]
        [ActionName(nameof(GetCliente))]
        public IEnumerable<Cliente> GetCliente()
        {
            return _clienteRepositorio.GetClientes();
        }

        [HttpGet("{ClienteId}")]
        [ActionName(nameof(GetClienteById))]
        public ActionResult<Cliente> GetClienteById(Guid clienteId)
        {
            var clienteByID = _clienteRepositorio.GetClienteById(clienteId);
            if (clienteByID == null)
            {
                return NotFound();
            }
            return clienteByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateClienteAsync))]
        public async Task<ActionResult<Cliente>> CreateClienteAsync(Cliente cliente)
        {
            await _clienteRepositorio.CreateClienteAsync(cliente);
            return CreatedAtAction(nameof(GetClienteById), new { ClienteId = cliente.ClienteId }, cliente);
        }

        [HttpPut("{ClienteId}")]
        [ActionName(nameof(UpdateCliente))]
        public async Task<ActionResult> UpdateCliente(Guid ClienteId, Cliente cliente)
        {
            if (ClienteId != cliente.ClienteId)
            {
                return BadRequest();
            }

            await _clienteRepositorio.UpdateClienteAsync(cliente);

            return NoContent();

        }
    }
}
