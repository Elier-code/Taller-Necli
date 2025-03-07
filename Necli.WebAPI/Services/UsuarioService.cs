using Necli.WebAPI.Entities;

namespace Necli.WebAPI.Services
{
    public interface IUsuarioService
    {
        bool ExisteCuenta(string telefono);
        Usuario ObtenerUsuarioPorTelefono(string telefono);
    }

    public class UsuarioService : IUsuarioService
    {
        private readonly List<Usuario> _usuarios = new()
    {
        new Usuario { Id = 1, Nombre = "Juan", Apellido = "Pérez", Email = "juan.perez@example.com", Telefono = "123456789", Saldo = 1500.75 },
        new Usuario { Id = 2, Nombre = "Ana", Apellido = "Gómez", Email = "ana.gomez@example.com", Telefono = "987654321", Saldo = 2300.50 }
        // Agrega más usuarios
    };

        public bool ExisteCuenta(string telefono)
        {
            return _usuarios.Any(u => u.Telefono == telefono);
        }

        public Usuario ObtenerUsuarioPorTelefono(string telefono)
        {
            return _usuarios.FirstOrDefault(u => u.Telefono == telefono)!;
        }
    }
}
