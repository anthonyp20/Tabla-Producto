namespace Financiera.Dominio
{
    public class Cliente
    {
        // GET => Leer
        // SET => Escribir
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Marca { get; set; }
        public string Precio { get; set; }
        public string Stock { get; set; }
        public bool Estado { get; set; }
       
    }
}
