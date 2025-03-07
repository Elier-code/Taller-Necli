using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Necli.WebAPI.Entities;
using Necli.WebAPI.Services;

namespace Necli.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        private readonly List<Transaccion> _transacciones = new();

        public TransaccionController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult RealizarTransaccion([FromBody] TransaccionRequest request)
        {
            // Validar que ambas cuentas existan
            if (!_usuarioService.ExisteCuenta(request.NumeroCuentaOrigen) ||
                !_usuarioService.ExisteCuenta(request.NumeroCuentaDestino))
            {
                return BadRequest("Una o ambas cuentas no existen.");
            }

            // Obtener los usuarios
            var usuarioOrigen = _usuarioService.ObtenerUsuarioPorTelefono(request.NumeroCuentaOrigen);
            var usuarioDestino = _usuarioService.ObtenerUsuarioPorTelefono(request.NumeroCuentaDestino);

            // Validar saldo suficiente en caso de salida
            if (request.Tipo == "salida" && usuarioOrigen.Saldo < request.Monto)
            {
                return BadRequest("Saldo insuficiente en la cuenta de origen.");
            }

            // Generar número de transacción (aleatorio de 5 dígitos)
            int numeroTransaccion = new Random().Next(10000, 99999);

            // Crear la transacción
            var transaccion = new Transaccion
            {
                Numero = numeroTransaccion,
                Fecha = DateTime.UtcNow,
                NumeroCuentaOrigen = request.NumeroCuentaOrigen,
                NumeroCuentaDestino = request.NumeroCuentaDestino,
                Monto = request.Monto,
                Tipo = request.Tipo
            };

            // Actualizar los saldos de los usuarios
            if (request.Tipo == "salida")
            {
                usuarioOrigen.Saldo -= request.Monto;
                usuarioDestino.Saldo += request.Monto;
            }

            // Guardar transacción (simulado)
            _transacciones.Add(transaccion);

            return Ok(new { Mensaje = "Transacción realizada con éxito", Transaccion = transaccion });
        }

    }
}
