using System;

namespace Financiera.Dominio
{
    public class DetallePrestamo
    {
        public int ID { get; set; }
        public int IdPrestamo { get; set; }
        public int NumeroCuota { get; set; }
        public decimal ImporteCuota { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Estado { get; set; }
    }
}
