using Necli.WebAPI.Entities;

namespace Necli.WebAPI.Services
{
    public class GestionTransaccion
    {
        public List<Usuario> Usuarios = new();


        public void UsuarioService()
        {

            Usuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Nombre = "Juan", Apellido = "Pérez", Email = "juan.perez@example.com", Telefono = "123456789", Saldo = 1500.75 },
                new Usuario { Id = 2, Nombre = "Ana", Apellido = "Gómez", Email = "ana.gomez@example.com", Telefono = "987654321", Saldo = 2300.50 },
                new Usuario { Id = 3, Nombre = "Carlos", Apellido = "López", Email = "carlos.lopez@example.com", Telefono = "564738291", Saldo = 320.00 },
                new Usuario { Id = 4, Nombre = "María", Apellido = "Fernández", Email = "maria.fernandez@example.com", Telefono = "102938475", Saldo = 500.25 },
                new Usuario { Id = 5, Nombre = "Pedro", Apellido = "Ramírez", Email = "pedro.ramirez@example.com", Telefono = "675849302", Saldo = 1200.90 },
                new Usuario { Id = 6, Nombre = "Sofía", Apellido = "Martínez", Email = "sofia.martinez@example.com", Telefono = "948576231", Saldo = 980.60 },
                new Usuario { Id = 7, Nombre = "Diego", Apellido = "Torres", Email = "diego.torres@example.com", Telefono = "123789456", Saldo = 2750.40 },
                new Usuario { Id = 8, Nombre = "Laura", Apellido = "Sánchez", Email = "laura.sanchez@example.com", Telefono = "456123789", Saldo = 670.85 },
                new Usuario { Id = 9, Nombre = "Hugo", Apellido = "Díaz", Email = "hugo.diaz@example.com", Telefono = "789456123", Saldo = 3400.00 },
                new Usuario { Id = 10, Nombre = "Elena", Apellido = "Castro", Email = "elena.castro@example.com", Telefono = "369258147", Saldo = 150.75 }
            };
        }

        public void Agregar(Transaccion transaccion)
        {
            // Cuenta.Add(transaccion);
        }
        
    }
}
