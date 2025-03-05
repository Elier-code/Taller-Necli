namespace Necli.WebAPI.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; init; }
        public double Saldo { get; set; }
    }
}
