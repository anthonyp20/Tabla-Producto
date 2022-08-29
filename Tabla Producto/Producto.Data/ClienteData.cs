using Financiera.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Financiera.Data
{
    public class ClienteData
    {
        string cadenaConexion = "server=localhost; Database=Financiera; Integrated Security = true";
        public List<Cliente> Listar()
        {
            var listado = new List<Cliente>();
            using(var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using(var comando = new SqlCommand("Select * From Cliente", conexion))
                {
                    using(var lector = comando.ExecuteReader())
                    {
                        if(lector != null && lector.HasRows)
                        {
                            Cliente cliente;
                            while (lector.Read())
                            {
                                cliente = new Cliente();
                                cliente.ID = int.Parse(lector[0].ToString());
                                cliente.Nombres = lector[1].ToString();
                                cliente.Marca = lector[2].ToString();
                                cliente.Precio = lector[3].ToString();
                                cliente.Stock = lector[4].ToString();
                                

                                listado.Add(cliente);
                            }
                        }
                    }
                }
            }
            return listado;
        }

        public Cliente BuscarPorId(int id)
        {
            Cliente cliente = new Cliente();
            using(var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using(var comando = new SqlCommand("SELECT * FROM Cliente WHERE ID = @id",conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    using(var lector = comando.ExecuteReader())
                    {
                        if(lector!= null && lector.HasRows)
                        {
                            lector.Read();
                            cliente = new Cliente();
                            cliente.ID = int.Parse(lector[0].ToString());
                            cliente.Nombres = lector[1].ToString();
                            cliente.Marca = lector[2].ToString();
                            cliente.Precio = lector[3].ToString();
                            cliente.Stock = lector[4].ToString();
                            
                        }
                    }
                }
            }
            return cliente;
        }

        public bool Insertar(Cliente cliente)
        {
            int filasInsertadas = 0;
            using(var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "INSERT INTO Cliente (Nombres,Marca, " +
                                "Direccion, Referencia, IdTipoCliente, IdTipoDocumento, " +
                                "NumeroDocumento, Estado)" +
                            "VALUES(@Nombres, @Apellidos, @Direccion, @Referencia, " +
                                "@IdTipoCliente, @IdTipoDocumento, @NumeroDocumento, @Estado)";
                using(var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                    comando.Parameters.AddWithValue("@Marca", cliente.Marca);
                    comando.Parameters.AddWithValue("@Precio", cliente.Precio);
                    comando.Parameters.AddWithValue("@Stock", cliente.Stock);
                    comando.Parameters.AddWithValue("@Estado", cliente.Estado);
                    comando.Parameters.AddWithValue("@ID", cliente.ID);
                    filasInsertadas = comando.ExecuteNonQuery();
                }
            }
            return filasInsertadas > 0;
        }

        public bool Actualizar(Cliente cliente)
        {
            int filasActualizadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "UPDATE Cliente SET Nombres = @Nombres, Apellidos = @Apellidos, " +
                    "Direccion = @Direccion, Referencia = @Referencia, " +
                    "IdTipoCliente = @IdTipoCliente, IdTipoDocumento = @IdTipoDocumento, " +
                    "NumeroDocumento = @NumeroDocumento, Estado = @Estado " +
                    "WHERE ID = @ID";
                using(var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                    comando.Parameters.AddWithValue("@Marca", cliente.Marca);
                    comando.Parameters.AddWithValue("@Precio", cliente.Precio);
                    comando.Parameters.AddWithValue("@Stock", cliente.Stock);
                    comando.Parameters.AddWithValue("@Estado", cliente.Estado);
                    comando.Parameters.AddWithValue("@ID", cliente.ID);
                    filasActualizadas = comando.ExecuteNonQuery();
                }
            }
            return filasActualizadas > 0;
        }

        public bool Eliminar(int id)
        {
            int filasEiminadas = 0;
            using(var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "DELETE FROM Cliente WHERE ID = @id";
                using(var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    filasEiminadas = comando.ExecuteNonQuery();
                }
            }
            return filasEiminadas > 0;
        }
    }
}
