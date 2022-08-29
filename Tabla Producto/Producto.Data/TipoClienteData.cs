using Financiera.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Financiera.Data
{
    public class TipoClienteData
    {
        string cadenaConexion = "server=localhost; database=Financiera; Integrated Security=true";
        public List<TipoCliente> Listar()
        {
            var listado = new List<TipoCliente>();
            using(var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using(var comando = new SqlCommand("SELECT * FROM TipoCliente", conexion))
                {
                    using(var lector = comando.ExecuteReader())
                    {
                        if(lector!= null && lector.HasRows)
                        {
                            TipoCliente tipo;
                            while (lector.Read())
                            {
                                tipo = new TipoCliente();
                                tipo.ID = int.Parse(lector[0].ToString());
                                tipo.Nombre = lector[1].ToString();
                                listado.Add(tipo);
                            }
                        }
                    }
                }
            }
            return listado;
        }

        public TipoCliente BuscarPorId(int id)
        {
            var tipoCliente = new TipoCliente();
            return tipoCliente;
        }

        public bool Insertar()
        {
            return true;
        }


    }
}
