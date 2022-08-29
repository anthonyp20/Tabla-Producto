using Financiera.Dominio;
using Financiera.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financiera.AppWin
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void IniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            var listado = ClienteBL.Listar();
            dgvListado.Rows.Clear();
            foreach (var cliente in listado)
            {
                dgvListado.Rows.Add(cliente.ID, cliente.Nombres, cliente.Marca,cliente.Precio,cliente.Stock);
            }            
        }

        private void nuevoRegistro(object sender, EventArgs e)
        {
            var nuevoCliente = new Cliente();
            var frm = new frmClienteEdit(nuevoCliente);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                var exito = ClienteBL.Insertar(nuevoCliente);
                if (exito)
                {
                    MessageBox.Show("El cliente ha sido registrado", "Financiera",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
                else
                {
                    MessageBox.Show("No se ha podido registrar al cliente", "Financiera",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editarRegistro(object sender, EventArgs e)
        {
            if(dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var idCliente = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var clienteEditar = ClienteBL.BuscarPorId(idCliente);
                var frm = new frmClienteEdit(clienteEditar);
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    var exito = ClienteBL.Actualizar(clienteEditar);
                    if (exito)
                    {
                        MessageBox.Show("El cliente ha sido actualizado", "Financiera",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido completar la operación de actualización", 
                            "Financiera", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void eliminarRegistro(object sender, EventArgs e)
        {
            if(dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var idCliente = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var nombreCliente = dgvListado.Rows[filaActual].Cells[1].Value.ToString();
                var rpta = MessageBox.Show("¿Realmente desea eliminar al cliente " + nombreCliente+ " ?",
                    "Financiera", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(rpta == DialogResult.Yes)
                {
                    var exito = ClienteBL.Eliminar(idCliente);
                    if (exito)
                    {
                        MessageBox.Show("El cliente ha sido eliminado.", "Financiera",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido completar la eliminación del cliente", 
                            "Financiera", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
