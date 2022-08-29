using Financiera.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Financiera.Data
{
    public class TipoDocumentoData
    {
        string cadenaConexion = "Server=localhost; Database=Financiera; Integrated Security=true";

        public List<TipoDocumento> Listar()
        {
            var listado = new List<TipoDocumento>();
            using(var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using(var comando = new SqlCommand("Select * From TipoDocumento", conexion))
                {
                    using(var lector = comando.ExecuteReader())
                    {
                        if(lector!= null && lector.HasRows)
                        {
                            TipoDocumento tipo;
                            while (lector.Read())
                            {
                                tipo = new TipoDocumento();
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
    }
}
