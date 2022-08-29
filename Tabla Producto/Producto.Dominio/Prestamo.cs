using System;

namespace Financiera.Dominio
{
    public class Prestamo
    {
        public int ID { get; set; }
        public string Numero { get; set; }
        public  DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public decimal Importe { get; set; }
        public decimal Tasa { get; set; }
        public int Plazo { get; set; }
        public DateTime FechaDeposito { get; set; }
        public bool Estado { get; set; }
    }
}
