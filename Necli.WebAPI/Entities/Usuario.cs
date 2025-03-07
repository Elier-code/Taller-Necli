namespace Necli.WebAPI.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public required string Telefono { get; init; }
        public double Saldo { get; set; }

        public Usuario() { }

        public Usuario(int id, string nombre, string apellido, string email, string telefono, double saldo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Telefono = telefono;
            Saldo = saldo;
        }


    }
}
