namespace Necli.WebAPI.Services
{
    public class TransaccionRequest
    {
        public required string NumeroCuentaOrigen { get; set; }
        public required string NumeroCuentaDestino { get; set; }
        public double Monto { get; set; }
        public required string Tipo { get; set; }
    }
}
