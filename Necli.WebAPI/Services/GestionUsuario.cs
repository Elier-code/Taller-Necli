using Necli.WebAPI.Entities;

namespace Necli.WebAPI.Services
{
    public class GestionUsuario
    {
        private List<Usuario> Usuarios = [];


        public void Agregar(Usuario usuario)
        {

            Usuarios.Add(usuario);
        }

        public Usuario Consultar(string telefono)
        {

            return Usuarios.FirstOrDefault(x => x.Telefono.Equals(telefono))!;
        }

        public bool Borra(string telefono)
        {
            var encontrado = Usuarios.FirstOrDefault(x => x.Telefono.Equals(telefono));

            if (encontrado is not null)
            {
                return Usuarios.Remove(encontrado);
            }

            return false;
        }

        public bool Actualizar(Usuario usuario)
        {
            var encontrado = Usuarios.FirstOrDefault(x => x.Telefono == usuario.Telefono);
            if (encontrado is not null)
            {
                encontrado.Nombre = usuario.Nombre;
                encontrado.Apellido = usuario.Apellido;
                encontrado.Email = usuario.Email;
                encontrado.Saldo = usuario.Saldo;

                return true;
            }

            return false;
        }
    }
}
