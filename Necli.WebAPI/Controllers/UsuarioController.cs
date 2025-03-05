using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Necli.WebAPI.Entities;
using Necli.WebAPI.Services;

namespace Necli.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly GestionUsuario gestionUsuario = new GestionUsuario();

        [HttpPost]
        public ActionResult<string> CrearUsuario(Usuario usuario)
        {
            gestionUsuario.Agregar(usuario);

            return Ok("Usuario creado");
        }

        [HttpGet("{telefono}")]
        public ActionResult<Usuario> consultarCuenta(string telefono)
        {
            if (!string.IsNullOrWhiteSpace(telefono))
            {
                var encontrado = gestionUsuario.Consultar(telefono);

                if (encontrado is not null)
                {
                    return Ok(encontrado);
                }
            }

            return NotFound("La cuenta a consultar no ha sido encontrada");
        }

        [HttpDelete]
        public ActionResult<string> BorrarUsuario(string telefono)
        {
            if (!string.IsNullOrWhiteSpace(telefono))
            {
                gestionUsuario.Borra(telefono);
                return Ok("la cuenta ha sido borrada");
            }

            return NotFound("La cuenta que intenta borrar no ha sido encontrada");
        }

        [HttpPut]
        public ActionResult<Usuario> Actualizar(string telefono, Usuario usuario)
        {
            int numeroIngresado = Int32.Parse(telefono);
            int numeroCuenta = Int32.Parse(usuario.Telefono);
            if (numeroIngresado <= 0 || numeroIngresado != numeroCuenta)
            {
                return BadRequest("El telefono ingresado no es valido");
            }

            var cuentaEncontrada = gestionUsuario.Consultar(telefono);

            if (cuentaEncontrada is not null)
            {
                cuentaEncontrada.Nombre = usuario.Nombre;
                cuentaEncontrada.Apellido = usuario.Apellido;
                cuentaEncontrada.Email = usuario.Email;
                cuentaEncontrada.Saldo = usuario.Saldo;

                gestionUsuario.Actualizar(cuentaEncontrada);

                return Ok("la cuenta ha sido actualizada");
            }

            return NotFound("La cuenta que intenta actualiza no ha sido encontrada");

        }
    }
}
