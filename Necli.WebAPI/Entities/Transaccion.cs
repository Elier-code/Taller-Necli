﻿namespace Necli.WebAPI.Entities
{
    public class Transaccion
    {
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public required string NumeroCuentaOrigen { get; set; }
        public required string NumeroCuentaDestino { get; set; }
        public Double Monto { get; set; }
        public string? Tipo { get; set; }

    }
}
